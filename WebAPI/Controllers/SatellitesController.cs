using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _satelliteService.GetAll();

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

        [HttpGet("getdetails")]
        public IActionResult GetCarDetails()
        {
            var result = _satelliteService.GetDetails();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Satellite satellite)
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
        public IActionResult Delete(Satellite satellite)
        {
            var result = _satelliteService.Delete(satellite);

            if (!result.Success)
                return BadRequest(result);

            return NoContent();
        }
    
    }
}
