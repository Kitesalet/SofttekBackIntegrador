using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Entities
{
    [Table("proyectos")]
    public class Proyecto : EntidadBase
    {

        [Key]
        [Column("codProyecto")]
        public int CodProyecto { get;set; }

        [Column("nombre")]
        public string Nombre { get;set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        /// <summary>
        /// Esta propiedad devuelve el estado del proyecto en formato numerico, comprendido los numeros 1 y 3
        /// </summary>
        [Column("estado")]
        [Range(1,3,ErrorMessage = "El valor del estado debe estar comprendido entre 1 y 3")]
        public int Estado { get; set; }

    }
}
