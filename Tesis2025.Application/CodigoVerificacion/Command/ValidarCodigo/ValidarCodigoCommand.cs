using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Tesis2025.Application.CodigoVerificacion.Command.ValidarCodigo
{
    public class ValidarCodigoCommand : IRequest<ValidarCodigoCommandDTO>
    {
        public string CorreoUsuario { get; set; }
        public string Codigo { get; set; }
    }
}
