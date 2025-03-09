using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MediatR;
using System.Reflection;

namespace UserManagement.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(i => i.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));            
            return services;
        }
    }
}
