using IntegradorSofttekImanol.Models.DTOs.OtherDtos;

namespace IntegradorSofttekImanol.Models.DTOs.Usuario
{
    /// <summary>
    /// Data transfer object for user login.
    /// </summary>
    public class UserLoginDTO
    {
        public string Name { get; set; }
        public int CodUser { get; set; }
        public string Type { get; set; }
        public string Token { get; set; }

    }
}
