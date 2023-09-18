using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    /// <summary>
    /// Represents a base entity.
    /// </summary>
    public class BaseEntity
    {

        [Column("fechaBaja", TypeName = "datetime2")]
        public DateTime? FechaBaja { get; set; }

        [Column("fechaAlta", TypeName = "datetime2")]
        [Required]
        public DateTime FechaAlta { get; set; }

        [Column("fechaUpdate", TypeName = "datetime2")]
        public DateTime? FechaUpdate { get; set; }
    }
}
