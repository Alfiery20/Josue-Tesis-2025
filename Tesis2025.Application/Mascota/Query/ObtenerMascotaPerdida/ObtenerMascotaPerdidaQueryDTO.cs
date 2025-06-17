using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesis2025.Application.Mascota.Query.ObtenerMascotaPerdida
{
    public class ObtenerMascotaPerdidaQueryDTO
    {
        public int Id { get; set; }
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
        public string Obtencion { get; set; }
        public string Tenencia { get; set; }
        public string Foto { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string FechaPerdida { get; set; }
        public string LugarPerdida { get; set; }
        public string Comentario { get; set; }
    }
}
