using AutoMapper;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Helpers
{
    public class MapperHelper : Profile
    {
        /// <summary>
        /// This constructor contains the logic for Entity-DTO mappings using the AutoMapper library and its methods.
        /// </summary>
        public MapperHelper() 
        {
            
            CreateMap<Proyecto, ProyectoDTO>().ReverseMap();
            CreateMap<Servicio,ServicioDTO>().ReverseMap();
            CreateMap<Trabajo, TrabajoDTO>().ReverseMap();




            #region Usuario mapping to their Dto class
            CreateMap<Usuario, UsuarioUpdateDto>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateDto>().ReverseMap();
            CreateMap<Usuario, UsuarioGetDto>().ReverseMap();
            CreateMap<Usuario, UsuarioLoginDto>().ReverseMap();
            #endregion

        }

    }
}
