using System;
using Microsoft.AspNetCore.Mvc;
using jobapi.Models;
using jobapi.Services;

namespace jobapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class JobContractorsController : ControllerBase
  {
    private readonly JobContractorsService _service;

    public JobContractorsController(JobContractorsService service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<JobContractor> Post([FromBody] JobContractor newJc)
    {
      try
      {
        return Ok(_service.Create(newJc));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}