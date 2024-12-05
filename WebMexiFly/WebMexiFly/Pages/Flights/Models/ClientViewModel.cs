using System;
using Microsoft.AspNetCore.Mvc;

namespace WebMexiFly.Pages.Flights.Models;

public class ClientViewModel
{
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
