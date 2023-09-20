using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user retrieval.
    /// </summary>
    public class UserGetDto
    {
        public int CodUser { get; set; }
        public string Name { get; set; }
        public int Dni { get; set; }
        public string Type { get; set; }

    }
}
