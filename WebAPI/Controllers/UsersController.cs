﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
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

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _userService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(Guid id)
    {
        var result = _userService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("add")]
    public IActionResult Add(User user)
    {
        var result = _userService.Add(user);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("delete")]
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

    [HttpPost("update")]
    public IActionResult Update(User user)
    {
        var result = _userService.Update(user);
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

    [HttpPost("user/edit")]
    public IActionResult EditProfile(UserForUpdateDto user)
    {
        var result = _userService.EditProfile(user);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

}
