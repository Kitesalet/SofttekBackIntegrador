using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("servicios")]
    public class Servicio : BaseEntity
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

        //Navigation Properties
        public List<Trabajo> Trabajo { get; set; }
    }
}
