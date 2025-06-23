using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface.Repositories;

namespace Tesis2025.Application.Autenticacion.Command.EditarUsuario
{
    public class EditarUsuarioCommandHandler : IRequestHandler<EditarUsuarioCommand, EditarUsuarioCommandDTO>
    {
        private readonly ILogger<EditarUsuarioCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAutenticacionRepository _autenticacionRepository;

        public EditarUsuarioCommandHandler(
            ILogger<EditarUsuarioCommandHandler> logger,
            IMapper mapper,
            IAutenticacionRepository autenticacionRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._autenticacionRepository = autenticacionRepository;
        }
        public Task<EditarUsuarioCommandDTO> Handle(EditarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var response = this._autenticacionRepository.EditarUsuario(request);
            return response;
        }
    }
}
