using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Tesis2025.Application.Mascota.Command.RegistrarMascotaPerdida
{
    public class RegistrarMascotaPerdidaCommand : IRequest<RegistrarMascotaPerdidaCommandDTO>
    {
        public string FechaPerdida { get; set; }
        public string LugarPerdida { get; set; }
        public string Comentario { get; set; }
        public int IdMascota { get; set; }
    }
}
