using ApplicaicationLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure
{
    public static class RegisterClass
    {

        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(Options=>Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOutboxRepository, OutboxRepository>();
        }
    }
}
