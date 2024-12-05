using System;

namespace MexiFly.Application.Features.Flight.Queries.List;

public class FlightListDto
{
    public long FlightId { get; set; }
    public string FlightCode { get; set; } = string.Empty; // Código del vuelo
    public string Origin { get; set; } = string.Empty; // Nombre del aeropuerto de origen
    public string Destination { get; set; } = string.Empty; // Nombre del aeropuerto de destino

    public List<FlightPrices> PricesCategory { get; set; } = new List<FlightPrices>();

    public DateTime DepartureDateTime { get; set; } // Fecha y hora de salida
    public int TotalSeats { get; set; } // Asientos disponibles
}


public class FlightPrices 
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public Decimal Price { get; set; }
}