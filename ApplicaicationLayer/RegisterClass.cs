using ApplicaicationLayer.Handlers;
using ApplicaicationLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicaicationLayer
{
    public static class RegisterClass
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderHandler,CreateOrderHandler>();
        }
    }
}
