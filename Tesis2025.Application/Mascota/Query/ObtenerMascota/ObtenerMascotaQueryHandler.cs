using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface.Repositories;

namespace Tesis2025.Application.Mascota.Query.ObtenerMascota
{
    public class ObtenerMascotaQueryHandler : IRequestHandler<ObtenerMascotaQuery, IEnumerable<ObtenerMascotaQueryDTO>>
    {
        private readonly ILogger<ObtenerMascotaQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMascotaRepository _mascotaRepository;

        public ObtenerMascotaQueryHandler(
            ILogger<ObtenerMascotaQueryHandler> logger,
            IMapper mapper,
            IMascotaRepository mascotaRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mascotaRepository = mascotaRepository;
        }
        public Task<IEnumerable<ObtenerMascotaQueryDTO>> Handle(ObtenerMascotaQuery request, CancellationToken cancellationToken)
        {
            var response = this._mascotaRepository.ObtenerMascotas(request);
            return response;
        }
    }
}
