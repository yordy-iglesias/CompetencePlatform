﻿using CompetencePlatform.Application.Models;

namespace CompetencePlatform.Application.Models.User;

public class CreateUserModel
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}

public class CreateUserResponseModel : BaseResponseModel { }
