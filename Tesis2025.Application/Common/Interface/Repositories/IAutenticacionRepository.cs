using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesis2025.Application.Autenticacion.Command.ActualizarClave;
using Tesis2025.Application.Autenticacion.Command.EditarUsuario;
using Tesis2025.Application.Autenticacion.Command.IniciarSesion;
using Tesis2025.Application.Autenticacion.Command.Registrar;

namespace Tesis2025.Application.Common.Interface.Repositories
{
    public interface IAutenticacionRepository
    {
        Task<IniciarSesionCommandDTO> IniciarSesion(IniciarSesionCommand command);
        Task<RegistrarCommandDTO> Registrar(RegistrarCommand command);
        Task<ActualizarClaveCommandDTO> ActualizarClave(ActualizarClaveCommand command);
        Task<EditarUsuarioCommandDTO> EditarUsuario(EditarUsuarioCommand command);
    }
}
