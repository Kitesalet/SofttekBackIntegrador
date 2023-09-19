namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user creation.
    /// </summary>
    public class UsuarioCreateDto
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Contrasena { get; set; }

    }
}
