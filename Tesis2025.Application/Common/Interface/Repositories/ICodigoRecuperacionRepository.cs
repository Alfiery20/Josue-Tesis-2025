using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesis2025.Application.Autenticacion.Command.ActualizarClave;
using Tesis2025.Application.CodigoVerificacion.Command.EnviarCodigo;
using Tesis2025.Application.CodigoVerificacion.Command.ValidarCodigo;

namespace Tesis2025.Application.Common.Interface.Repositories
{

    public interface ICodigoRecuperacionRepository
    {
        Task<EnviarCodigoCommandDTO> RegistrarCodigo(EnviarCodigoCommand command);
        Task<ValidarCodigoCommandDTO> ValidarCodigo(ValidarCodigoCommand command);
        Task<string> ObtenerCorreoUsuario(int idUsuario);
    }
}
