using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Tesis2025.Application.Autenticacion.Command.EditarUsuario
{
    public class EditarUsuarioCommand : IRequest<EditarUsuarioCommandDTO>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
