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
        public DateTime? DeletedDate { get; set; }

        [Column("fechaAlta", TypeName = "datetime2")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column("fechaUpdate", TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }
    }
}
