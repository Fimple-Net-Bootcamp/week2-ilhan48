﻿using Core.Entities.Abstract;

namespace Entities.DTOs.UserDtos;

public class UserForLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
