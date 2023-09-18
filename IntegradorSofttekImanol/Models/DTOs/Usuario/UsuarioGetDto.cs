using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user retrieval.
    /// </summary>
    public class TrabajoDto
    {
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Tipo { get; set; }
        public DateTime? FechaBaja { get; set; }

    }
}
