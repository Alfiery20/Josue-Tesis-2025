using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Tesis2025.Application.Common.Interface;
using Tesis2025.Application.Common.Settings;

namespace Tesis2025.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime HoraLocal()
        {
            var horaActualPacifico = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
            var fechaActual = horaActualPacifico;
            return fechaActual.DateTime;
        }
    }
}
