using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface;
using Tesis2025.Application.Common.Interface.Repositories;

namespace Tesis2025.Application.Autenticacion.Command.IniciarSesion
{
    public class IniciarSesionCommandHandler : IRequestHandler<IniciarSesionCommand, IniciarSesionCommandDTO>
    {
        private readonly ILogger<IniciarSesionCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAutenticacionRepository _autenticacionRepository;
        private readonly IJwtService _jwtService;
        private readonly IDateTimeService _dateTimeService;

        public IniciarSesionCommandHandler(
            ILogger<IniciarSesionCommandHandler> logger,
            IMapper mapper,
            IAutenticacionRepository autenticacionRepository,
            IJwtService jwtService,
            IDateTimeService dateTimeService)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._autenticacionRepository = autenticacionRepository;
            this._jwtService = jwtService;
            this._dateTimeService = dateTimeService;
        }
        public async Task<IniciarSesionCommandDTO> Handle(IniciarSesionCommand request, CancellationToken cancellationToken)
        {
            var response = await this._autenticacionRepository.IniciarSesion(request);
            if (response.Id != 0)
            {
                response.Token = this.GenerateToken(response);
            }
            return response;
        }

        private string GenerateToken(IniciarSesionCommandDTO command)
        {
            var claims = new List<Claim>
            {
                new Claim("identifier", command.Id.ToString() ?? ""),
                new Claim("nombres", command.Nombre ?? ""),
                new Claim("apellido", command.Apellido ?? ""),
                new Claim("documento", command.NumeroDocumento ?? ""),
                new Claim("direccion", command.Direccion ?? ""),
                new Claim("distrito", command.Distrito ?? ""),
                new Claim("correo", command.Correo ?? ""),
            };

            var token = _jwtService.Generate(claims.ToArray(), this._dateTimeService.HoraLocal());

            return token;
        }
    }
}
