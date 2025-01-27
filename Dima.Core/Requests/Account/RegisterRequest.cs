﻿using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Account;

public class RegisterRequest : BaseRequest
{
    [Required(ErrorMessage = "E-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha")]
    public string Password { get; set; } = string.Empty;
}