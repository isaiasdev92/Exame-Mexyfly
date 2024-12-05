using System;
using MediatR;
using MexiFly.Entities;
using MexiFly.Infrastructure.Interfaces;
using MexiFly.Transversal.Common;

namespace MexiFly.Application.Features.Flight.Queries.List;

public class GetListFlightQueryHandler : IRequestHandler<GetFlightlistQuery, ResponseGeneral<List<FlightListDto>>>
{
    private readonly IFlightRepository _flightRepository;
    public GetListFlightQueryHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }
    public async Task<ResponseGeneral<List<FlightListDto>>> Handle(GetFlightlistQuery request, CancellationToken cancellationToken)
    {
        var response = await _flightRepository.GetFlights();
        
        var list = new List<FlightListDto>();
        foreach (var item in response)
        {
            list.Add(new FlightListDto() {
                DepartureDateTime = item.DepartureDateTime,
                Origin = item.OriginAirport.NameAirport,
                Destination = item.DestinationAirport.NameAirport,
                FlightCode = item.FlightCode,
                TotalSeats = item.TotalSeats,
                FlightId = item.FlightId,
                PricesCategory = GetPrices(item.TblRates.ToList())
            });
        }

        
        return new ResponseGeneral<List<FlightListDto>>() {
            Data = list,
            Status = ResponseStatus.Success.ToString()
        };
    }

    private List<FlightPrices> GetPrices (List<TblRate> rates) 
    {
       var result = rates.Select(x => new FlightPrices() 
        {
            Price = x.Price,
            CategoryId = x.CategoryId,
            CategoryName = x.Category.CategoryName
        }).ToList();


        return result;
    }

}
