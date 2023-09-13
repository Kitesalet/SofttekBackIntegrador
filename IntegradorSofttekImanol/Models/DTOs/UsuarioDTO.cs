using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntegradorSofttekImanol.Models.DTOs
{
    public class UsuarioDTO
    {
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Tipo { get; set; }
        public string Contrasena { get; set; }
        public string Token { get; set; }
    }
}
