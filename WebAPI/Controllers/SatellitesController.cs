using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.SatelliteDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SatellitesController : ControllerBase
    {
        readonly ISatelliteService _satelliteService;

        public SatellitesController(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }

        [HttpPost]
        public IActionResult Add(SatelliteAddDto satellite)
        {
            var result = _satelliteService.Add(satellite);

            if (!result.Success)
                return BadRequest(result);

            return Created("", result);
        }

        [HttpPut]
        public IActionResult Update(Satellite satellite)
        {
            var result = _satelliteService.Update(satellite);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(SatelliteDeleteDto satellite)
        {
            var result = _satelliteService.Delete(satellite);

            if (!result.Success)
                return BadRequest(result);

            return NoContent();
        }

        [HttpPatch("editsatellite/{id}")]
        public IActionResult PatchProfile(int id, [FromBody] JsonPatchDocument<SatelliteDetailDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest(ModelState);
            }

            var satelliteFromRepo = _satelliteService.GetById(id);
            if (satelliteFromRepo == null)
            {
                return NotFound();
            }

            var satelliteToPatch = new SatelliteDetailDto();

            patchDocument.ApplyTo(satelliteToPatch, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) => ModelState.AddModelError("JsonPatch", err.ErrorMessage));

            if (!TryValidateModel(satelliteToPatch))
            {
                return BadRequest(ModelState);
            }

            var result = _satelliteService.EditSatellite(satelliteToPatch);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string name, string sortOrder)
        {
            var result = _satelliteService.GetAll(name, sortOrder);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _satelliteService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    
    }
}
