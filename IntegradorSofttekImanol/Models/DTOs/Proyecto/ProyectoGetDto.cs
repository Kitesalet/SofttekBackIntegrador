using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Models.DTOs.Proyecto
{
    public class ProyectoGetDto
    {
        public int CodProyecto { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Estado Estado { get; set; }
        public List<TrabajoGetMinDto> Trabajos { get; set; }

    }
}
