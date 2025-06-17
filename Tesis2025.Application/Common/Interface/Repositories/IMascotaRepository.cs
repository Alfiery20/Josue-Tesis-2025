using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesis2025.Application.Mascota.Command.RegistrarMascota;
using Tesis2025.Application.Mascota.Command.RegistrarMascotaPerdida;
using Tesis2025.Application.Mascota.Query.ObtenerMascota;
using Tesis2025.Application.Mascota.Query.ObtenerMascotaPerdida;

namespace Tesis2025.Application.Common.Interface.Repositories
{
    public interface IMascotaRepository
    {
        Task<RegistrarMascotaCommandDTO> RegistrarMascota(RegistrarMascotaCommand command);
        Task<RegistrarMascotaPerdidaCommandDTO> RegistrarMascotaPerdida(RegistrarMascotaPerdidaCommand command);
        Task<IEnumerable<ObtenerMascotaQueryDTO>> ObtenerMascotas(ObtenerMascotaQuery query);
        Task<IEnumerable<ObtenerMascotaPerdidaQueryDTO>> ObtenerMascotasPerdidas(ObtenerMascotaPerdidaQuery query);
    }
}
