using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IntegradorSofttekImanol.Entities;

namespace IntegradorSofttekImanol.DTOs
{
    public class ServicioDTO
    {
        public int CodServicio { get; set; }
        public string Descr { get; set; }
        public bool Estado { get; set; }
        public decimal ValorHora { get; set; }

    }
}
