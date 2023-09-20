namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user authentication.
    /// </summary>
    public class UserAuthenticateDTO
    {
        public string CodUser { get; set; }
        public string Password { get; set; }
    }
}
