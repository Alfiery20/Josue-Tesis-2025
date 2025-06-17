using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface.Repositories;

namespace Tesis2025.Application.CodigoVerificacion.Command.ValidarCodigo
{
    public class ValidarCodigoCommandHandler : IRequestHandler<ValidarCodigoCommand, ValidarCodigoCommandDTO>
    {
        private readonly ILogger<ValidarCodigoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICodigoRecuperacionRepository _codigoRecuperacionRepository;

        public ValidarCodigoCommandHandler(
            ILogger<ValidarCodigoCommandHandler> logger,
            IMapper mapper,
            ICodigoRecuperacionRepository codigoRecuperacionRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._codigoRecuperacionRepository = codigoRecuperacionRepository;
        }
        public Task<ValidarCodigoCommandDTO> Handle(ValidarCodigoCommand request, CancellationToken cancellationToken)
        {
            var response = this._codigoRecuperacionRepository.ValidarCodigo(request);
            return response;
        }
    }
}
