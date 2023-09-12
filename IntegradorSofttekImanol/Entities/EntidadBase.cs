using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Entities
{
    public class EntidadBase
    {
        [Column("fechaBaja")]
        public DateTime? FechaBaja { get; set; }

        [Column("fechaAlta")]
        public DateTime FechaAlta { get; set; }

        [Column("fechaUpdate")]
        public DateTime? FechaUpdate { get; set; }

    }
}
