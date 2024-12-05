using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMexiFly.Pages.Flights.Models;

public class FlightsViewModel
{
    public long FlightId { get; set; }
    public string FlightCode { get; set; } = string.Empty; // Código del vuelo
    public string Origin { get; set; } = string.Empty; // Nombre del aeropuerto de origen
    public string Destination { get; set; } = string.Empty; // Nombre del aeropuerto de destino

    public List<FlightPrices> PricesCategory { get; set; } = new List<FlightPrices>();

    public SelectList PricesCategorySelect { get; set; }

    public DateTime DepartureDateTime { get; set; } // Fecha y hora de salida
    public int TotalSeats { get; set; } // Asientos disponibles
}


public class FlightPrices 
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public decimal Price { get; set; }
}