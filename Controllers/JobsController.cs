using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobapi.Models;
using jobapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace jobapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class JobsController : ControllerBase
  {


    private readonly JobsService _js;
    private readonly ContractorsService _cs;

    public JobsController(JobsService js, ContractorsService cs)
    {
      _js = js;
      _cs = cs;
    }

    // GET api/kits
    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_js.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/kits/5
    [HttpGet("{id}")]
    public ActionResult<Job> Get(int id)
    {
      try
      {
        return Ok(_js.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/kits
    [HttpPost]
    public ActionResult<Job> Post([FromBody] Job newJob)
    {
      try
      {
        return Ok(_js.Create(newJob));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/kits/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_js.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{jobId}/jobcontractors")]
    public ActionResult<IEnumerable<Contractor>> GetJobContractors(int jobId)
    {
      try
      {
        return Ok(_cs.GetContractorsByJobId(jobId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}