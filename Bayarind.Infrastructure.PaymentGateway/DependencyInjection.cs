using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Bayarind.Infrastructure.PaymentGateway.Interface;
using Bayarind.Infrastructure.PaymentGateway.Service;
//using Bayarind.Infrastructure.HttpRequest.Interface;
//using Bayarind.Infrastructure.HttpRequest.Service;

namespace Homeplate.Infrastructure.PaymentGateway
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPaymentGateway(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IPaymentGatewayService, PaymentGatewayService>();

            return services;
        }
    }
}
