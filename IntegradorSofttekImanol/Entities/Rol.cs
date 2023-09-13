using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Entities
{
    [Table("roles")]
    public class Rol : EntidadBase
    {

        [Column("rolId")]
        public int Id { get; set; }

        [Column("rolName")]
        public string Name { get; set; }

        [Column("rolDescription")]
        public string Description { get; set; }


    }
}
