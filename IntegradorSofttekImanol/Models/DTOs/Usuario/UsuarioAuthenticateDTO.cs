namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user authentication.
    /// </summary>
    public class UsuarioAuthenticateDTO
    {
        public string CodUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}
