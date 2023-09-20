using IntegradorSofttekImanol.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("usuarios")]
    /// <summary>
    /// Represents a user entity.
    /// </summary>
    public class User : BaseEntity
    {
        [Key]
        [Column("codUsuario")]
        public int CodUser { get; set; }

        [Column("nombre", TypeName = "varchar(60)")]
        [Required]
        public string Name { get; set; }

        [Column("dni", TypeName = "int")]
        [Required]
        [Range(10000000, 99999999, ErrorMessage = "The input number is invalid")]
        public int Dni { get; set; }

        [Column("tipo",TypeName = "int")]
        [Required]
        [Range(1, 2, ErrorMessage = "The input number is invalid")]
        public UserRole Type { get; set; }

        [Column("contrasena",TypeName = "varchar(200)")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Please, introduce a valid password")]
        [Required]
        public string Password { get; set; }

    }
}
