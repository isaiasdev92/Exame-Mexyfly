using System;
using MediatR;
using MexiFly.Transversal.Common;

namespace MexiFly.Application.Features.Flight.Queries.List;

public class GetFlightlistQuery : IRequest<ResponseGeneral<List<FlightListDto>>>
{

}
    