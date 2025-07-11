using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Tesis2025.Application.Autenticacion.Command.ActualizarClave
{
    public class ActualizarClaveCommand : IRequest<ActualizarClaveCommandDTO>
    {
        public string CorreoUsuario { get; set; }
        public string Clave { get; set; }
    }
}
