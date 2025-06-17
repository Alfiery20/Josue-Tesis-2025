using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface.Repositories;

namespace Tesis2025.Application.Mascota.Command.RegistrarMascota
{
    public class RegistrarMascotaCommandHandler : IRequestHandler<RegistrarMascotaCommand, RegistrarMascotaCommandDTO>
    {
        private readonly ILogger<RegistrarMascotaCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMascotaRepository _mascotaRepository;

        public RegistrarMascotaCommandHandler(
            ILogger<RegistrarMascotaCommandHandler> logger,
            IMapper mapper,
            IMascotaRepository mascotaRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mascotaRepository = mascotaRepository;
        }
        public Task<RegistrarMascotaCommandDTO> Handle(RegistrarMascotaCommand request, CancellationToken cancellationToken)
        {
            var response = this._mascotaRepository.RegistrarMascota(request);
            return response;
        }
    }
}
