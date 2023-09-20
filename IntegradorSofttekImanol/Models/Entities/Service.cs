using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("servicios")]
    /// <summary>
    /// Represents a service entity.
    /// </summary>
    public class Service : BaseEntity
    {
        [Key]
        [Column("codServicio", TypeName = "int")]
        public int CodService { get; set; }

        [Column("descr", TypeName = "varchar(200)")]
        [Required]
        public string Descr { get; set; }

        [Column("estado", TypeName = "bit")]
        public bool State { get; set; }

        [Column("valorHora", TypeName = "decimal(18, 2)")]
        [Required]
        public decimal HourValue { get; set; }

        // Navigation Properties
        public List<Work> Works { get; set; }
    }
}
