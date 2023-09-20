namespace IntegradorSofttekImanol.Models.DTOs.Trabajo
{
    public class WorkCreateDto
    {
        public DateTime Date { get; set; }
        public int CodProject { get; set; }
        public int CodService { get; set; }
        public int HourQty { get; set; }
        public decimal HourValue { get; set; }

    }
}