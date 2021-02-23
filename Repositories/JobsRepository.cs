using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using jobapi.Models;
namespace jobapi.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Job> Get()
    {
      string sql = "SELECT * FROM jobs;";
      return _db.Query<Job>(sql);
    }

    internal Job Get(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id;";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }

    internal int Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (title, rate)
      VALUES
      (@Title, @Rate);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newJob);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @id;";
      _db.Execute(sql, new { id });
    }
  }
}