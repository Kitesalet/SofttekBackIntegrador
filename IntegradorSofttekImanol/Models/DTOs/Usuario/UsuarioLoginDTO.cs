namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user login.
    /// </summary>
    public class UsuarioLoginDto
    {
        public string Nombre { get; set; }
        public int CodUsuario { get; set; }
        public int Tipo { get; set; }
        public string Token { get; set; }

    }
}
