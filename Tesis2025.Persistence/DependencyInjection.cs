using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Tesis2025.Application.Common.Interface;
using Tesis2025.Application.Common.Interface.Repositories;
using Tesis2025.Persistence.Database;
using Tesis2025.Persistence.Repository;


namespace Tesis2025.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDataBase>(sp => new SqlDataBase(connectionString));

            services.AddSingleton<IAutenticacionRepository, AutenticacionRepository>();
            services.AddSingleton<ICodigoRecuperacionRepository, CodigoRecuperacionRepository>();
            services.AddSingleton<IMascotaRepository, MascotaRepository>();

            return services;
        }
    }
}
