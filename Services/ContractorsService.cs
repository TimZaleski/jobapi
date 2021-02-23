using System;
using System.Collections.Generic;
using jobapi.Models;
using jobapi.Repositories;

namespace jobapi.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;
    private readonly JobsRepository _jrepo;

    public ContractorsService(ContractorsRepository repo, JobsRepository jrepo)
    {
      _repo = repo;
      _jrepo = jrepo;
    }


    internal IEnumerable<Contractor> Get()
    {
      return _repo.Get();
    }
    internal Contractor Get(int id)
    {
      Contractor exists = _repo.Get(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    internal Contractor Create(Contractor newContractor)
    {
      int id = _repo.Create(newContractor);
      newContractor.Id = id;
      return newContractor;
    }


    internal string Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
      return "Successfully Deleted";
    }



    internal IEnumerable<Contractor> GetContractorsByJobId(int kitId)
    {
      Job exists = _jrepo.Get(kitId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.GetContractorsByJobId(kitId);
    }
  }
}