using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Entities.DTOs.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Add(User user)
    {
        var result = _userService.Add(user);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete]
    public IActionResult Delete(User user)
    {
        var result = _userService.Delete(user);
        if (result.Success)
        {
            return Ok(result);
        }
        if (result.Message == Messages.AuthorizationDenied)
        {
            return Unauthorized();
        }
        return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update(User user)
    {
        var result = _userService.Update(user);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPatch("editprofile/{id}")]
    public IActionResult PatchProfile(Guid id, [FromBody] JsonPatchDocument<UserForUpdateDto> patchDocument)
    {
        if (patchDocument == null)
        {
            return BadRequest(ModelState);
        }

        var userFromRepo = _userService.GetById(id);
        if (userFromRepo == null)
        {
            return NotFound();
        }

        var userToPatch = new UserForUpdateDto(); 

        patchDocument.ApplyTo(userToPatch, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) => ModelState.AddModelError("JsonPatch", err.ErrorMessage));

        if (!TryValidateModel(userToPatch))
        {
            return BadRequest(ModelState);
        }

        var result = _userService.EditProfile(userToPatch);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] bool status, string sortOrder, int page = 1, int size = 10)
    {
        var result = _userService.GetAll(status, sortOrder, page, size);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    //[HttpGet]
    //public IActionResult GetAll([FromQuery] bool status, string sortOrder)
    //{
    //    var result = _userService.GetAll(status, sortOrder);
    //    if (result.Success)
    //    {
    //        return Ok(result);
    //    }
    //    return BadRequest(result);
    //}

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById(Guid id)
    {
        var result = _userService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

   
    [HttpGet("getbymail")]
    public IActionResult GeyByMail(string email)
    {
        var result = _userService.GetByMail(email);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
