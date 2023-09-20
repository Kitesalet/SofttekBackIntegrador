namespace IntegradorSofttekImanol.Models.DTOs.Trabajo
{
    public class WorkGetDto
    {
        public int codWork { get; set; }
        public DateTime Date { get; set; }
        public int CodProyect { get; set; }
        public int CodService { get; set; }
        public int HourQty { get; set; }
        public decimal HourValue { get; set; }
        public decimal Cost { get; set; }
    }
}
