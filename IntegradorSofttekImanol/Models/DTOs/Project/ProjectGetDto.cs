using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.Enums;

namespace IntegradorSofttekImanol.Models.DTOs.Proyecto
{
    public class ProjectGetDto
    {
        public int CodProject { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public List<WorkGetMinDto> Works { get; set; }

    }
}
