using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MexiFly.Application;

public static class InjectionApplicationExtension
{
    public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration) 
    {
        //Busca todas las clases para aplicarle la configuración de la validación
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //Busca todas las configuración del MediatR para aplicarle las configuracuones necesarias
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}

