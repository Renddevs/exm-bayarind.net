﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Bayarind.Infrastructure.HttpRequest.Interface;
using Bayarind.Infrastructure.HttpRequest.Service;
//using Bayarind.Infrastructure.HttpRequest.Interface;
//using Bayarind.Infrastructure.HttpRequest.Service;

namespace Homeplate.Infrastructure.PaymentGateway
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterHttpRequest(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IHttpRequest, HttpRequestServices>();

            return services;
        }
    }
}
