using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("usuarios")]
    public class Usuario : BaseEntity
    {

        [Key]
        [Column("codUsuario")]
        public int CodUsuario { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("dni")]
        [Range(10000000, 99999999, ErrorMessage = "El DNI ingresado es invalido")]
        public int Dni { get; set; }

        [Column("tipo")]
        [Range(1, 2, ErrorMessage = "El tipo debe estar comprendido entre los numeros 1 y 2")]
        [ForeignKey("Rol")]
        public int Tipo { get; set; }

        [Column("contrasena")]
        public string Contrasena { get; set; }


        //Navigation Properties

        public Rol? Rol { get; set; }
    }
}
