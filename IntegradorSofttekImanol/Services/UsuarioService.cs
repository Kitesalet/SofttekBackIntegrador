using AutoMapper;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateUsuario(UsuarioCreateDto usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);
                //Cargar su rol luego
                await _unitOfWork.UsuarioRepository.AddAsync(usuario);

                await _unitOfWork.Complete();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " - Error");
            }

            return false;

        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {

            var flag = _unitOfWork.UsuarioRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;

        }

        public async Task<IEnumerable<UsuarioLoginDto>> GetAllUsuariosAsync()
        {
            
            return _mapper.Map<List<UsuarioLoginDto>>(await _unitOfWork.UsuarioRepository.GetAll());

        }

        public async Task<UsuarioLoginDto> GetUsuarioByIdAsync(int id)
        {
            
            var usuario = await _unitOfWork.UsuarioRepository.GetById(id);

            return _mapper.Map<UsuarioLoginDto>(usuario);
            
        }

        public async Task<bool> UpdateUsuario(UsuarioUpdateDto usuarioDto)
        {
            try
            {

                var usuario = await _unitOfWork.UsuarioRepository.GetById(usuarioDto.CodUsuario);

                _unitOfWork.UsuarioRepository.Update(usuario);

                await _unitOfWork.Complete();

                return true;

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return false;


        }
    }
}
