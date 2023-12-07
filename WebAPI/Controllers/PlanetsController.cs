using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.PlanetDtos;
using Microsoft.AspNetCore.JsonPatch;
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
    public IActionResult Add(PlanetAddDto planet)
    {
        var result = _planetService.Add(planet);
        if (result.Success) 
        {
            return CreatedAtAction(nameof(Add), planet);
        }
        return BadRequest(result);
    }

    [HttpDelete]
    public IActionResult Delete(PlanetDeleteDto planet) 
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

    [HttpPatch("editplanet/{id}")]
    public IActionResult PatchProfile(int id, [FromBody] JsonPatchDocument<PlanetDetailDto> patchDocument)
    {
        if (patchDocument == null)
        {
            return BadRequest(ModelState);
        }

        var userFromRepo = _planetService.GetById(id);
        if (userFromRepo == null)
        {
            return NotFound();
        }

        var planetToPatch = new PlanetDetailDto();

        patchDocument.ApplyTo(planetToPatch, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) => ModelState.AddModelError("JsonPatch", err.ErrorMessage));

        if (!TryValidateModel(planetToPatch))
        {
            return BadRequest(ModelState);
        }

        var result = _planetService.EditPlanet(planetToPatch);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }


    [HttpGet]
    public IActionResult GetAll([FromQuery] string name, string sortOrder)
    {
        var result = _planetService.GetAll(name, sortOrder);
        if (result.Success)
        {
            return Ok(result);
        }
        else if (result.Message == Messages.NoMatchingContent)
        {
            return NotFound();
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
