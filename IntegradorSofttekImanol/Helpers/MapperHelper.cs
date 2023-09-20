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
            CreateMap<Rol, RolDto>().ReverseMap();
            #endregion

            #region Proyecto mapping to their Dto class
            CreateMap<Proyecto, ProyectoGetDto>().ReverseMap();
            CreateMap<Proyecto, ProyectoUpdateDto>().ReverseMap();
            CreateMap<Proyecto, ProyectoCreateDto>().ReverseMap();
            #endregion

            #region Servicio mapping to their Dto class
            CreateMap<Servicio,ServicioGetDto>().ReverseMap();
            CreateMap<Servicio, ServicioUpdateDto>().ReverseMap();
            CreateMap<Servicio, ServicioCreateDto>().ReverseMap();
            #endregion

            #region Trabajo mapping to their Dto class
            CreateMap<Trabajo, TrabajoGetDto>().ReverseMap();
            CreateMap<Trabajo, TrabajoGetMinDto>().ReverseMap();
            CreateMap<Trabajo, TrabajoCreateDto>().ReverseMap();
            CreateMap<Trabajo, TrabajoUpdateDto>().ReverseMap();
            #endregion

            #region Usuario mapping to their Dto class
            CreateMap<Usuario, UsuarioUpdateDto>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateDto>().ReverseMap();
            CreateMap<Usuario, UsuarioGetDto>().ReverseMap();
            CreateMap<Usuario, UsuarioLoginDto>().ReverseMap();
            #endregion

        }

    }
}
