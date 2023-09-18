using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("usuarios")]
    /// <summary>
    /// Represents a user entity.
    /// </summary>
    public class Usuario : BaseEntity
    {
        [Key]
        [Column("codUsuario")]
        public int CodUsuario { get; set; }

        [Column("nombre", TypeName = "varchar(60)")]
        [Required]
        public string Nombre { get; set; }

        [Column("dni", TypeName = "int")]
        [Required]
        [Range(10000000, 99999999, ErrorMessage = "The input number is invalid")]
        public int Dni { get; set; }

        [Column("tipo",TypeName = "int")]
        [Required]
        [Range(1, 2, ErrorMessage = "The input number is invalid")]
        [ForeignKey("Rol")]
        public int Tipo { get; set; }

        [Column("contrasena",TypeName = "varchar(200)")]
        [Required]
        public string Contrasena { get; set; }

        // Navigation Properties
        public Rol Rol { get; set; }
    }
}
