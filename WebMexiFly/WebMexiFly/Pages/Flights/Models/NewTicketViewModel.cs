using System;

namespace WebMexiFly.Pages.Flights.Models;

public class NewTicketViewModel
{
    public long ClientId { get; set; }

    public int CategoryId { get; set; }

    public long FlightId { get; set; }
}
