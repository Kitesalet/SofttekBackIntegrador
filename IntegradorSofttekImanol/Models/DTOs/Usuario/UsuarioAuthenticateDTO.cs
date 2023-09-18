namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user authentication.
    /// </summary>
    public class UsuarioAuthenticateDTO
    {
        public string Dni { get; set; }
        public string contrasena { get; set; }
    }
}
