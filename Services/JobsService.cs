using System;
using System.Collections.Generic;
using jobapi.Models;
using jobapi.Repositories;

namespace jobapi.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Job> Get()
    {
      return _repo.Get();
    }
    internal Job Get(int id)
    {
      Job exists = _repo.Get(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    internal Job Create(Job newJob)
    {
      int id = _repo.Create(newJob);
      newJob.Id = id;
      return newJob;
    }

    internal string Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}