using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.DTOs.Servicio;

namespace IntegradorSofttekImanol.Models.DTOs.Trabajo
{
    public class WorkGetDto
    {
        public int codWork { get; set; }
        public DateTime Date { get; set; }
        public ProjectGetDto Project { get; set; }
        public ServiceGetDto Service{ get; set; }
        public int HourQty { get; set; }
        public decimal HourValue { get; set; }
        public decimal Cost { get; set; }
    }
}
