using AutoMapper;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{
    /// <summary>
    /// The implementation of the service for defining and using UserDtos and its logic.
    /// </summary>
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes an instance of UserService using dependency injection with its parameters.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI.</param>
        /// <param name="mapper">IMapper with DI.</param>
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<bool> CreateUserAsync(UserCreateDto UserDto)
        {
            try
            {
                var User = _mapper.Map<User>(UserDto);

                User.Password = EncrypterHelper.Encrypter(User.Password, $"RaNdOmCoDe");

                await _unitOfWork.UserRepository.AddAsync(User);

                User.CreatedDate = DateTime.Now;

                User.Type = 1;

                await _unitOfWork.Complete();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " - Error");
            }

            return false;

        }

        /// <inheritdoc/>
        public async Task<bool> DeleteUserAsync(int id)
        {

            var flag = await _unitOfWork.UserRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;

        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserGetDto>> GetAllUsersAsync(int page, int units)
        {

            var Users = await _unitOfWork.UserRepository.GetAllAsync(page, units, e => e.Role);      
            
            return _mapper.Map<List<UserGetDto>>(Users);
                   
        }

        /// <inheritdoc/>
        public async Task<UserGetDto> GetUserByIdAsync(int id)
        {
            
            var User = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if(User == null || User.DeletedDate != null)
            {
                return null;
            }

            return _mapper.Map<UserGetDto>(User);
            
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateUser(UserUpdateDto userDto)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userDto.CodUser);

            if (user == null)
            {
                return false;
            }

            user.Name = userDto.Name;
            user.Type = userDto.Type;
            user.Password = userDto.Password;
            user.UpdatedDate = DateTime.Now;

            _unitOfWork.UserRepository.Update(user);

            await _unitOfWork.Complete();

            return true;

        }
    }
}
