namespace IntegradorSofttekImanol.Models.DTOs.Servicio
{
    public class ServiceUpdateDto
    {
        public int CodService { get; set; }
        public string Descr { get; set; }
        public bool State { get; set; }
        public decimal HourValue { get; set; }
        public DateTime? DeletedDate { get; set; }


    }
}
