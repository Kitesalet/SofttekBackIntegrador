using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Models.DTOs.Proyecto
{
    public class ProjectGetDto
    {
        public int CodProyect { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ProjectState State { get; set; }
        public List<WorkGetMinDto> Works { get; set; }

    }
}
