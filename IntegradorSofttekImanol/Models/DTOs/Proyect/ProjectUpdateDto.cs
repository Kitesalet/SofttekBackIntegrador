using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Models.DTOs.Proyecto
{
    public class ProjectUpdateDto
    {
        public int CodProyect { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ProyectState State { get; set; }
    }
}
