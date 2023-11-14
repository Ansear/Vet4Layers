using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UnitOfWork;
using AspNetCoreRateLimit;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace WebApi.Extensions;
public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>//Permitir cualquier Origen de Peticion
    services.AddCors(Options =>
    {
        Options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin() //WithOrigins("http://dominio.com")
            .AllowAnyMethod()        //WithMethods("GET","POST")
            .AllowAnyHeader()        //WithHeaders("Accept","content-type")
        );
    });

    public static void ConfigureRateLimiting(this IServiceCollection services) //Limite de Peticiones
    {
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(options =>
        {
            options.EnableEndpointRateLimiting = true;
            options.StackBlockedRequests = false;
            options.HttpStatusCode = 429;
            options.RealIpHeader = "X-Real-IP";
            options.GeneralRules = new List<RateLimitRule>
            {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Period = "10s", //Tiempo
                        Limit = 2 //Cantidad de peticiones segun el tiempo
                    }
            };
        });
    }

    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options => 
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new QueryStringApiVersionReader("ver");//Variable que permitira especificar la version a utilizar en la petición
        });
    }
}