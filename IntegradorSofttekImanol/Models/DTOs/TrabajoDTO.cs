using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntegradorSofttekImanol.Models.DTOs
{
    public class TrabajoDto
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
