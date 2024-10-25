﻿using Domain.Models.FilteredOrders;
using Domain.Models.Orders;
using Infrastructure.Db;
using Infrastructure.Db.Interface;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DepenedncyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<IDbContext, OrderDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IFilteredResultRepository, FilteredResultRepository>();

            return services;
        }
    }
}
