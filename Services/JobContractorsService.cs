using System;
using jobapi.Models;
using jobapi.Repositories;

namespace jobapi.Services
{
  public class JobContractorsService
  {
    private readonly JobContractorsRepository _repo;

    public JobContractorsService(JobContractorsRepository repo)
    {
      _repo = repo;
    }

    public JobContractor Create(JobContractor newJc)
    {
      int id = _repo.Create(newJc);
      newJc.Id = id;
      return newJc;
    }

    internal string Delete(int id)
    {
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}