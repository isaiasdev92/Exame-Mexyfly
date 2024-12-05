using System;
using Microsoft.AspNetCore.Mvc;

namespace WebMexiFly.Pages.Users.Models;

public class RegistrationUserModel
{    
    [BindProperty]
    public string Username { get; set; } = string.Empty;
    [BindProperty]
    public string Password { get; set; } = string.Empty;
    [BindProperty]
    public string FirstName { get; set; } = string.Empty;
    [BindProperty]
    public string LastNameP { get; set; } = string.Empty;
    [BindProperty]
    public string LastNameM { get; set; } = string.Empty;
    [BindProperty]
    public string Email { get; set; } = string.Empty;
    [BindProperty]
    public string PhoneNumber { get; set; } = string.Empty;
}
