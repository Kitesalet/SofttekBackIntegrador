using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Entities
{
    [Table("trabajos")]
    public class Trabajo : EntidadBase
    {

        [Key]
        [Column("codTrabajo")]
        public int CodTrabajo { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("codProyecto")]
        [ForeignKey("Proyecto")]
        public int CodProyecto { get; set; }

        [Column("codServicio")]
        [ForeignKey("Servicio")]
        public int CodServicio { get; set; }

        [Column("cantHoras")]
        public int CantHoras { get; set; }

        [Column("valorHora")]
        public decimal valorHora { get; set; }

        private decimal _Costo { get; set; }

        /// <summary>
        /// Esta propiedad devuelve el producto de las propiedades ValorHora y CantHoras
        /// </summary>
        [Column("costo")]  
        public decimal Costo
        {
            set
            {
                _Costo = valorHora * CantHoras;
            }
            get
            {
                return _Costo;
            }
        }

        //Navigation Properties
        public Servicio Servicio { get; set; }
        public Proyecto Proyecto { get; set; }

    }
}
