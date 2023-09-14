using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;

namespace IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces
{
    public interface IUsuarioService
    {

        Task<IEnumerable<UsuarioGetDto>> GetAllUsuariosAsync(bool condition);
        Task<UsuarioGetDto> GetUsuarioByIdAsync(int id);
        Task<bool> CreateUsuarioAsync(UsuarioCreateDto usuarioDto);
        Task<bool> UpdateUsuario(UsuarioUpdateDto usuarioDto);
        Task<bool> DeleteUsuarioAsync(int id);

    }
}
