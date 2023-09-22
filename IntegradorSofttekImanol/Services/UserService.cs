﻿using AutoMapper;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.Dictionaries;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Enums;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
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
        public async Task<bool> CreateUserAsync(UserCreateDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);

                user.Password = EncrypterHelper.Encrypter(user.Password, $"RaNdOmCoDe");

                await _unitOfWork.UserRepository.AddAsync(user);

                user.CreatedDate = DateTime.Now;

                user.Type = UserRole.Consultor;

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

            var users = await _unitOfWork.UserRepository.GetAllAsync(page, units); 
            
            var usersDto = new List<UserGetDto>();
            
            return usersDto;
                   
        }

        /// <inheritdoc/>
        public async Task<UserGetDto> GetUserByIdAsync(int id)
        {
            
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if(user == null || user.DeletedDate != null)
            {
                return null;
            }

            return _mapper.Map<UserGetDto>(user);
            
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
            user.Type = (UserRole)userDto.Type;
            user.Password = userDto.Password;
            user.UpdatedDate = DateTime.Now;

            _unitOfWork.UserRepository.Update(user);

            await _unitOfWork.Complete();

            return true;

        }
    }
}