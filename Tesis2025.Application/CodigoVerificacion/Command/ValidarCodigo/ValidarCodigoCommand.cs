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
        public int IdUsuario { get; set; }
        public string Codigo { get; set; }
    }
}
