using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("proyectos")]

    /// <summary>
    /// Represents a project entity.
    /// </summary>
    public class Proyecto : BaseEntity
    {
        [Key]
        [Column("codProyecto", TypeName = "int")]
        public int CodProyecto { get; set; }

        [Column("nombre", TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }

        [Column("direccion", TypeName = "varchar(100)")]
        [Required]
        public string Direccion { get; set; }

        /// <summary>
        /// This property returns the class status in numeric format, which only should contain the numbers 1, 2, and 3.
        /// </summary>
        [Column("estado", TypeName = "int")]
        [Range(1, 3, ErrorMessage = "The value of this property should be between 1 and 3")]
        public Estado Estado { get; set; }

        // Navigation properties
        public List<Trabajo> Trabajos { get; set; }
    }
}
