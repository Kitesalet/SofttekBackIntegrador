using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("servicios")]
    /// <summary>
    /// Represents a service entity.
    /// </summary>
    public class Servicio : BaseEntity
    {
        [Key]
        [Column("codServicio", TypeName = "int")]
        public int CodServicio { get; set; }

        [Column("descr", TypeName = "varchar(200)")]
        [Required]
        public string Descr { get; set; }

        [Column("estado", TypeName = "bit")]
        public bool Estado { get; set; }

        [Column("valorHora")]
        [Required]
        public decimal ValorHora { get; set; }

        // Navigation Properties
        public List<Trabajo> Trabajo { get; set; }
    }
}
