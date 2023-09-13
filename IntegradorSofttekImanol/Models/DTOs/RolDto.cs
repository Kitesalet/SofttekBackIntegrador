using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Models.DTOs
{
    public class RolDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Activo { get; set; }

    }
}