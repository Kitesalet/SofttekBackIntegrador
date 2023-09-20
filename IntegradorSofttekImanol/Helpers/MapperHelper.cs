using AutoMapper;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Helpers
{
    /// <summary>
    /// This class provides a mean to configure mappings between classes
    /// </summary>
    public class MapperHelper : Profile
    {
        /// <summary>
        /// This constructor contains the logic for Entity-DTO mappings using the AutoMapper library and its methods.
        /// </summary>
        public MapperHelper() 
        {
            #region Rol mapping to their Dto class
            CreateMap<Role, RoleDto>().ReverseMap();
            #endregion

            #region Proyecto mapping to their Dto class
            CreateMap<Proyect, ProyectoGetDto>().ReverseMap();
            CreateMap<Proyect, ProyectoUpdateDto>().ReverseMap();
            CreateMap<Proyect, ProyectoCreateDto>().ReverseMap();
            #endregion

            #region Servicio mapping to their Dto class
            CreateMap<Service,ServiceGetDto>().ReverseMap();
            CreateMap<Service, ServiceUpdateDto>().ReverseMap();
            CreateMap<Service, ServicioCreateDto>().ReverseMap();
            #endregion

            #region Trabajo mapping to their Dto class
            CreateMap<Work, WorkGetDto>().ReverseMap();
            CreateMap<Work, WorkGetMinDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            #endregion

            #region Usuario mapping to their Dto class
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserGetDto>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            #endregion

        }

    }
}
