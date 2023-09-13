using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("roles")]
    public class Rol : EntidadBase
    {
        [Key]
        [Column("codRol")]
        public int codRol { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("description")]
        public string Descripcion { get; set; }

        
        //Navigation Properties

        public IEnumerable<Usuario> Usuarios { get; set; }

    }
}
