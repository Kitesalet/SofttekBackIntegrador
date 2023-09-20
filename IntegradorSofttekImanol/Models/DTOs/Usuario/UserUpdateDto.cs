namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user update.
    /// </summary>
    public class UserUpdateDto
    {
        public int CodUser { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Password { get; set; }

    }
}
