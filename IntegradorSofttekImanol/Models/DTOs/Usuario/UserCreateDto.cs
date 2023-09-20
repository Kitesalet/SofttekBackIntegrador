namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user creation.
    /// </summary>
    public class UserCreateDto
    {
        public string Name { get; set; }
        public int Dni { get; set; }
        public string Password { get; set; }

    }
}
