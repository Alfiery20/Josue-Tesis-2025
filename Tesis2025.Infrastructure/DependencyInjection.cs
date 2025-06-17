using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Tesis2025.Application.Common.Interface;
using Tesis2025.Infrastructure.Crytography;
using Tesis2025.Infrastructure.Services;

namespace Tesis2025.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<ICryptography, Cryptography>();
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IEmailService, EmailService>();
            return services;
        }

    }
}
