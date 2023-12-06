using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _userService.GetAll();
        return Ok(result);

    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _userService.GetById(id);
        return Ok(result);
        
    }

    [HttpPost("add")]
    public IActionResult Add(User user)
    {
        return Ok();
        
    }

    [HttpPost("delete")]
    public IActionResult Delete(User user)
    {
        return Ok();
        
    }

    [HttpPost("update")]
    public IActionResult Update(User user)
    {
        return Ok();
        
    }

    [HttpGet("getbymail")]
    public IActionResult GeyByMail(string email)
    {
        return Ok();
        
    }

    [HttpPost("user/edit")]
    public IActionResult EditProfile(UserForUpdateDto user)
    {
        return Ok();
    }

}
