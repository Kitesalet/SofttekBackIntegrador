using IntegradorSofttekImanol.Models.DTOs.Usuario;

namespace IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces
{
    public interface IUsuarioService
    {

        Task<IEnumerable<UsuarioLoginDto>> GetAllUsuariosAsync();
        Task<UsuarioLoginDto> GetUsuarioByIdAsync(int id);
        Task<bool> CreateUsuario(UsuarioCreateDto usuarioDto);
        Task<bool> UpdateUsuario(UsuarioUpdateDto usuarioDto);
        Task<bool> DeleteUsuarioAsync(int id);

    }
}
