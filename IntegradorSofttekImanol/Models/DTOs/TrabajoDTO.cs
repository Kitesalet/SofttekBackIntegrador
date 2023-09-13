using IntegradorSofttekImanol.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntegradorSofttekImanol.DTOs
{
    public class TrabajoDTO
    {

        public int codTrabajo { get; set; }
        public DateTime Fecha { get; set; }
        public int CodProyecto { get; set; }
        public int CodServicio { get; set; }
        public int CantHoras { get; set; }
        public decimal valorHora { get; set; }
        public decimal Costo { get; set; }

    }
}
