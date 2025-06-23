using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface;
using Tesis2025.Application.Common.Interface.Repositories;

namespace Tesis2025.Application.CodigoVerificacion.Command.EnviarCodigo
{
    public class EnviarCodigoCommandHandler : IRequestHandler<EnviarCodigoCommand, EnviarCodigoCommandDTO>
    {
        private readonly ILogger<EnviarCodigoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICodigoRecuperacionRepository _codigoRecuperacionRepository;
        private readonly IEmailService _emailService;

        public EnviarCodigoCommandHandler(
            ILogger<EnviarCodigoCommandHandler> logger,
            IMapper mapper,
            ICodigoRecuperacionRepository codigoRecuperacionRepository,
            IEmailService emailService
            )
        {
            this._logger = logger;
            this._mapper = mapper;
            this._codigoRecuperacionRepository = codigoRecuperacionRepository;
            this._emailService = emailService;
        }
        public async Task<EnviarCodigoCommandDTO> Handle(EnviarCodigoCommand request, CancellationToken cancellationToken)
        {
            Random random = new Random();
            int numero = random.Next(0, 1000000);
            var codigoRecuperacion = numero.ToString("D6");
            request.Codigo = codigoRecuperacion;

            var response = await this._codigoRecuperacionRepository.RegistrarCodigo(request);
            if (response.Codigo == "OK")
            {

                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Utils", "Templates", "EmailTemplateVerificacion.html");
                string html = File.ReadAllText(ruta).Replace("{{CODIGO}}", request.Codigo);


                //var correoUsuario = await this._codigoRecuperacionRepository.ObtenerCorreoUsuario(request.CorreoUsuario);
                this._emailService.EnviarCorreo(request.CorreoUsuario, "Codigo de Verificacion", html, true);
            }
            return response;
        }
    }
}
