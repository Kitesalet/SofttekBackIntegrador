using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.DTOs
{
    public class RolDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

    }
}