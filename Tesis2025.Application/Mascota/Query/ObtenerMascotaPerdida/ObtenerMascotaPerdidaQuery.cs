using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Tesis2025.Application.Mascota.Query.ObtenerMascota;

namespace Tesis2025.Application.Mascota.Query.ObtenerMascotaPerdida
{
    public class ObtenerMascotaPerdidaQuery : IRequest<IEnumerable<ObtenerMascotaPerdidaQueryDTO>>
    {
        public string Termino { get; set; }
    }
}
