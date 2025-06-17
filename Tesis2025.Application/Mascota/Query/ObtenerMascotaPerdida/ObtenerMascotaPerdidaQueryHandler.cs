using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface.Repositories;
using Tesis2025.Application.Mascota.Query.ObtenerMascota;

namespace Tesis2025.Application.Mascota.Query.ObtenerMascotaPerdida
{
    public class ObtenerMascotaPerdidaQueryHandler : IRequestHandler<ObtenerMascotaPerdidaQuery, IEnumerable<ObtenerMascotaPerdidaQueryDTO>>
    {
        private readonly ILogger<ObtenerMascotaPerdidaQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMascotaRepository _mascotaRepository;

        public ObtenerMascotaPerdidaQueryHandler(
            ILogger<ObtenerMascotaPerdidaQueryHandler> logger,
            IMapper mapper,
            IMascotaRepository mascotaRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mascotaRepository = mascotaRepository;
        }
        public Task<IEnumerable<ObtenerMascotaPerdidaQueryDTO>> Handle(ObtenerMascotaPerdidaQuery request, CancellationToken cancellationToken)
        {
            var response = this._mascotaRepository.ObtenerMascotasPerdidas(request);
            return response;
        }
    }
}
