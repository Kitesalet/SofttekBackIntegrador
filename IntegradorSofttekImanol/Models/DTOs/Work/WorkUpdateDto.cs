﻿namespace IntegradorSofttekImanol.Models.DTOs.Trabajo
{
    public class WorkUpdateDto
    {
        public int codWork { get; set; }
        public DateTime Date { get; set; }
        public int CodProject { get; set; }
        public int CodService { get; set; }
        public int HourQty { get; set; }
        public decimal HourValue { get; set; }

    }
}