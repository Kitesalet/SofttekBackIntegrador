using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("roles")]

    /// <summary>
    /// Represents a role entity.
    /// </summary>
    public class Role : BaseEntity
    {
        [Key]
        [Column("codRol", TypeName = "int")]
        public int CodRole { get; set; }

        [Column("nombre", TypeName = "varchar(45)")]
        [Required]
        public string Name { get; set; }

        [Column("descripcion", TypeName = "varchar(200)")]
        [Required]
        public string Description { get; set; }

        // Navigation Properties
        public IEnumerable<User> Usuarios { get; set; }
    }
}
