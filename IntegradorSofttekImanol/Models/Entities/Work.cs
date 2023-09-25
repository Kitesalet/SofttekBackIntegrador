using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.Entities
{
    [Table("trabajos")]

    /// <summary>
    /// Represents a work entity.
    /// </summary>
    public class Work : BaseEntity
    {

        [Key]
        [Column("codTrabajo", TypeName = "int")]
        public int CodWork { get; set; }

        [Column("fecha", TypeName = "datetime2")]
        [Required]
        public DateTime Date { get; set; }

        [Column("codProyecto", TypeName = "int")]
        [ForeignKey("Project")]
        [Required]
        public int CodProject { get; set; }

        [Column("codServicio", TypeName = "int")]
        [ForeignKey("Service")]
        [Required]
        public int CodService { get; set; }

        [Column("cantHoras", TypeName = "int")]
        [Required]
        public int HourQty { get; set; }

        [Column("valorHora", TypeName = "decimal(18, 2)")]
        [Required]
        public decimal HourValue { get; set; }

        /// <summary>
        /// This property returns the product of ValorHora and CantHoras properties.
        /// </summary>
        [Column("costo", TypeName = "decimal(18, 2)")]
        [Required]
        public decimal Cost
        {
            private set
            {
                
            }
            get
            {
                return HourQty * HourValue;
            }
        }

        //Navigation Properties & Keys

        public Service Service { get; set; }
        public Project Project { get; set; }

    }
}
