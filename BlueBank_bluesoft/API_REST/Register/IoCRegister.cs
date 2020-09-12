using API_REST.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_REST.Register
{
    //Clase para registrar nuestros servicios a IServiceCollection
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterRepositories(services);
            return services;
        }

        //private static IServiceCollection AddRegisterServices(IServiceCollection services)
        //{
        //    services.AddTransient<ICuentaService, CuentaService>();
        //    services.AddTransient<ITransaccionService, TransaccionService>();

        //    return services;
        //}

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<ICuentaRepository, CuentaRepository>();
            services.AddTransient<ITransaccionRepository, TransaccionRepository>();

            return services;
        }
    }
}
