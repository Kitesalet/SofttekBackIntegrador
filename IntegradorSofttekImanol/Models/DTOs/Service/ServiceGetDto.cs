using IntegradorSofttekImanol.Models.DTOs.Trabajo;

namespace IntegradorSofttekImanol.Models.DTOs.Servicio
{
    public class ServiceGetDto
    {
        public int CodService { get; set; }
        public string Descr { get; set; }
        public bool State { get; set; }
        public decimal HourValue { get; set; }
        public IEnumerable<WorkGetMinDto> Works { get;set;}
    }
}
