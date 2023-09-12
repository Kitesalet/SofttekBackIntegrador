using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Entities
{
    [Table("servicios")]
    public class Servicio : EntidadBase
    {

        [Key]
        [Column("codServicio")]
        public int CodServicio { get; set; }

        [Column("descr")]
        public string Descr { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }

        [Column("valorHora")]
        public decimal ValorHora { get; set; }

    }
}
