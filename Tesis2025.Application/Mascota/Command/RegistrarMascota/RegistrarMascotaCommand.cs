using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Tesis2025.Application.Mascota.Command.RegistrarMascota
{
    public class RegistrarMascotaCommand : IRequest<RegistrarMascotaCommandDTO>
    {
        public string Nombre { get; set; }
        public string FechaNacimiento { get; set; }
        public string Especie { get; set; }
        public string Genero { get; set; }
        public string Raza { get; set; }
        public string Tamanio { get; set; }
        public string Caracter { get; set; }
        public string Color { get; set; }
        public string Pelaje { get; set; }
        public string Esterelizado { get; set; }
        public string Distrito { get; set; }
        public string ModoObtencion { get; set; }
        public string RazonTenencia { get; set; }
        public string Foto { get; set; }
        public int IdUsuario { get; set; }
    }
}
