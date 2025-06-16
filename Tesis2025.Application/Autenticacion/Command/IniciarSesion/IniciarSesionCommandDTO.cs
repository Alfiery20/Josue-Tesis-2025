using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesis2025.Application.Autenticacion.Command.IniciarSesion
{
    public class IniciarSesionCommandDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string Correo { get; set; }
        public string Token { get; set; }
    }
}
