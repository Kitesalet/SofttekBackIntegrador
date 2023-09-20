﻿using IntegradorSofttekImanol.Models.DTOs.Trabajo;

namespace IntegradorSofttekImanol.Models.DTOs.Servicio
{
    public class ServicioGetDto
    {
        public int CodServicio { get; set; }
        public string Descr { get; set; }
        public bool Estado { get; set; }
        public decimal ValorHora { get; set; }
        public List<TrabajoGetMinDto> Trabajos { get;set;}
    }
}
