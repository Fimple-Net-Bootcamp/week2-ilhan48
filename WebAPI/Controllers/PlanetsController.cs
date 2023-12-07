using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PlanetsController : ControllerBase
{
    IPlanetService _planetService;
    public PlanetsController(IPlanetService planetService)
    {
        _planetService = planetService;       
    }

    [HttpPost]
    public IActionResult Add(Planet planet)
    {
        var result = _planetService.Add(planet);
        if (result.Success) 
        {
            return CreatedAtAction(nameof(Add), planet);
        }
        return BadRequest(result);
    }

    [HttpDelete]
    public IActionResult Delete(Planet planet) 
    {
        var result = _planetService.Delete(planet);
        if (result.Success)
        {
            return NoContent();
        }
        return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update(Planet planet)
    {
        var result = _planetService.Update(planet);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _planetService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) 
    {
        var result = _planetService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getplanetdetailbyid/{id}")]
    public IActionResult GetPlanetDetail(int id)
    {
        var result = _planetService.GetPlanetDetails(id);
        if(result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getplanetdetails")]
    public IActionResult GetPlanetDetails()
    {
        var result = _planetService.GetPlanetsDetails();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
