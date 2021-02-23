using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using jobapi.Models;
namespace jobapi.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Contractor> Get()
    {
      string sql = "SELECT * FROM contractors;";
      return _db.Query<Contractor>(sql);
    }

    internal Contractor Get(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id;";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    internal int Create(Contractor newContractor)
    {
      string sql = @"
      INSERT INTO contractors
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newContractor);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id = @id;";
      _db.Execute(sql, new { id });
    }


    internal IEnumerable<Contractor> GetContractorsByJobId(int jobId)
    {
      string sql = @"
      SELECT c.*,
      jc.id as JobContractorId 
      FROM jobcontractors jc
      JOIN contractors c ON c.id = jc.contractorId
      WHERE jc.jobId = @jobId";

      return _db.Query<JobContractorViewModel>(sql, new { jobId });
    }
  }
}