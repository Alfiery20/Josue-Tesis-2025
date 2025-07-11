using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Tesis2025.Application.Mascota.Query.ObtenerMascota
{
    public class ObtenerMascotaQuery : IRequest<IEnumerable<ObtenerMascotaQueryDTO>>
    {
        public int IdUsuario { get; set; }
    }
}
