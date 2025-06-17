using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface.Repositories;

namespace Tesis2025.Application.Autenticacion.Command.ActualizarClave
{
    public class ActualizarClaveCommandHandler : IRequestHandler<ActualizarClaveCommand, ActualizarClaveCommandDTO>
    {
        private readonly ILogger<ActualizarClaveCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAutenticacionRepository _autenticacionRepository;

        public ActualizarClaveCommandHandler(
            ILogger<ActualizarClaveCommandHandler> logger,
            IMapper mapper,
            IAutenticacionRepository autenticacionRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._autenticacionRepository = autenticacionRepository;
        }
        public Task<ActualizarClaveCommandDTO> Handle(ActualizarClaveCommand request, CancellationToken cancellationToken)
        {
            var response = this._autenticacionRepository.ActualizarClave(request);
            return response;
        }
    }
}
