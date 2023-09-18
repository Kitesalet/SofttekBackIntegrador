using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("proyectos")]
    public class Proyecto : BaseEntity
    {
        [Key]
        [Column("codProyecto")]
        public int CodProyecto { get; set; }

        [Column("nombre", TypeName = "varchar(255)")]
        [Required]
        public string Nombre { get; set; }

        [Column("direccion", TypeName = "varchar(255)")]
        [Required]
        public string Direccion { get; set; }

        /// <summary>
        /// This property returns the class status in numeric format, which only should contain the numbers 1, 2, and 3.
        /// </summary>
        [Column("estado")]
        [Range(1, 3, ErrorMessage = "The value of this property should be between 1 and 3")]
        public Estado Estado { get; set; }

        // Navigation properties
        public List<Trabajo> Trabajo { get; set; }
    }
}
