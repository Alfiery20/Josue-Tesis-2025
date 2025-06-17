using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface.Repositories;
using Tesis2025.Application.Mascota.Command.RegistrarMascota;

namespace Tesis2025.Application.Mascota.Command.RegistrarMascotaPerdida
{
    public class RegistrarMascotaPerdidaCommandHandler : IRequestHandler<RegistrarMascotaPerdidaCommand, RegistrarMascotaPerdidaCommandDTO>
    {
        private readonly ILogger<RegistrarMascotaPerdidaCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMascotaRepository _mascotaRepository;

        public RegistrarMascotaPerdidaCommandHandler(
            ILogger<RegistrarMascotaPerdidaCommandHandler> logger,
            IMapper mapper,
            IMascotaRepository mascotaRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mascotaRepository = mascotaRepository;
        }
        public Task<RegistrarMascotaPerdidaCommandDTO> Handle(RegistrarMascotaPerdidaCommand request, CancellationToken cancellationToken)
        {
            var response = this._mascotaRepository.RegistrarMascotaPerdida(request);
            return response;
        }
    }
}
