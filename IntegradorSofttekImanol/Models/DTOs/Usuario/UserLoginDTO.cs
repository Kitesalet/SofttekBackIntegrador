namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user login.
    /// </summary>
    public class UserLoginDTO
    {
        public string Name { get; set; }
        public int CodUser { get; set; }
        public int Type { get; set; }
        public string Token { get; set; }
        public RoleDto Role { get; set; }

    }
}
