using Microsoft.Extensions.DependencyInjection;
using TravelPort.Domain.Repository;
using TravelPort.Domain.Service;
using TravelPort.Infrastructure.Repositories;
using TravelPort.Infrastructure.Services;

namespace TravelPort.Infrastructure.Common
{
    public static  class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPeopleService, PeopleService>();

            services.AddScoped<IPeopleRepository, PeopleRepository>();
            return services;
        }
    }
}