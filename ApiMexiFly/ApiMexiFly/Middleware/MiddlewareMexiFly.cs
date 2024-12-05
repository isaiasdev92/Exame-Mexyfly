using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using MexiFly.Transversal.Common;
using MexiFly.Transversal.ExceptionCustom;
using Newtonsoft.Json;

namespace MexiFly.Services.WebApi.Middleware;

public class MiddlewareMexiFly
{
    private readonly RequestDelegate _next;
    private readonly ILogger<MiddlewareMexiFly> _logger;


    public MiddlewareMexiFly(RequestDelegate next, ILogger<MiddlewareMexiFly> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Guid guid = Guid.NewGuid();
        _logger.LogInformation($"REQUEST INIT: {guid}");
        try
        {
            await _next(context);
            _logger.LogInformation($"REQUEST FINISH: {guid}");            
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            int statusCode = (int)HttpStatusCode.InternalServerError;

            var response = new ResponseGeneral<object>();

            switch (ex)
            {
                case NotFoundException notFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = ex.Message;
                    response.Status = ResponseStatus.Error.ToString();
                    break;

                case UnauthorizedException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = ex.Message;
                    response.Status = ResponseStatus.Error.ToString();
                    break;

                case BadRequestException badRequestException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = ex.Message;
                    response.Status = ResponseStatus.Error.ToString();
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = ex.Message;
                    response.Status = ResponseStatus.Error.ToString();
                    break;
            }

            var resultJson = JsonConvert.SerializeObject(response);

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(resultJson);

        }

    }

}
