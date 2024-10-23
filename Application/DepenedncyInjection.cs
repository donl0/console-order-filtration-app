using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DepenedncyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICreateOrederService, CreateOrderService>();
            services.AddTransient<IFilterOrdersServise, FilterOrdersServise>();
            return services;
        }
    }
}
