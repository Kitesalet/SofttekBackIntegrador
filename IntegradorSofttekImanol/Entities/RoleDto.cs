using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofttekImanol.Entities
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Activo { get; set; }

    }
}