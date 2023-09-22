namespace IntegradorSofttekImanol.Models.DTOs.Trabajo
{
    public class WorkUpdateDto
    {
        public int CodWork { get; set; }
        public DateTime Date { get; set; }
        public int CodProject { get; set; }
        public int CodService { get; set; }
        public int HourQty { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}