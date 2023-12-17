using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vleko.Bayarind.Core.Attributes;
using Vleko.Bayarind.Core.Helper;
using System.Reflection;

namespace Vleko.Bayarind.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.Configure<ApplicationConfig>(options => configuration.Bind(nameof(ApplicationConfig), options));
            
            var type = typeof(DependencyInjection);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IGeneralHelper, GeneralHelper>();
            services.AddTransient<IEmailHelper, EmailHelper>();
            services.AddTransient<ITokenHelper, TokenHelper>();
            return services;
        }
    }
}
