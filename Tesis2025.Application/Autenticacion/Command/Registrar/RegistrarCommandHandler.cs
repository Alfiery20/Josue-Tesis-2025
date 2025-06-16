using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface.Repositories;

namespace Tesis2025.Application.Autenticacion.Command.Registrar
{
    public class RegistrarCommandHandler : IRequestHandler<RegistrarCommand, RegistrarCommandDTO>
    {
        private readonly ILogger<RegistrarCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAutenticacionRepository _autenticacionRepository;

        public RegistrarCommandHandler(
            ILogger<RegistrarCommandHandler> logger,
            IMapper mapper,
            IAutenticacionRepository autenticacionRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._autenticacionRepository = autenticacionRepository;
        }
        public Task<RegistrarCommandDTO> Handle(RegistrarCommand request, CancellationToken cancellationToken)
        {
            var response = this._autenticacionRepository.Registrar(request);
            return response;
        }
    }
}
