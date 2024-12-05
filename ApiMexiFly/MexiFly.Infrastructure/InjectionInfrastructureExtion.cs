using System;
using MexiFly.Infrastructure.Data;
using MexiFly.Infrastructure.Interfaces;
using MexiFly.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MexiFly.Infrastructure;

public static class InjectionInfrastructureExtion
{
    public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration) 
    {

        services.AddScoped<IAirportRepository, AirportRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<IRateRepository, RateRepository>();
        services.AddScoped<ISegmentRepository, SegmentRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IUserInfoRepository, UserInfoRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        Console.WriteLine("");

        services.AddDbContext<MexiflyDbContext> (opt => opt.UseMySQL(configuration.GetConnectionString("DefaultConnection")!));

        return services;
    }
}
