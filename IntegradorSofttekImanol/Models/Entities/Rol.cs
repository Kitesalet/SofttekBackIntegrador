using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("roles")]

    /// <summary>
    /// Represents a role entity.
    /// </summary>
    public class Rol : BaseEntity
    {
        [Key]
        [Column("codRol", TypeName = "int")]
        public int CodRol { get; set; }

        [Column("nombre", TypeName = "varchar(45)")]
        [Required]
        public string Nombre { get; set; }

        [Column("descripcion", TypeName = "varchar(200)")]
        [Required]
        public string Descripcion { get; set; }

        // Navigation Properties
        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}
