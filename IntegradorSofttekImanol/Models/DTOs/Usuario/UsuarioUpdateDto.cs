namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user update.
    /// </summary>
    public class UsuarioUpdateDto
    {
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public string Contrasena { get; set; }

    }
}
