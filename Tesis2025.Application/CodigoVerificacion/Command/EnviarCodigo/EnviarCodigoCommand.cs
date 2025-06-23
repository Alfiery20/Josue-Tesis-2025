using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Tesis2025.Application.CodigoVerificacion.Command.EnviarCodigo
{
    public class EnviarCodigoCommand : IRequest<EnviarCodigoCommandDTO>
    {
        public string CorreoUsuario { get; set; }
        public string Codigo { get; set; }
    }
}
