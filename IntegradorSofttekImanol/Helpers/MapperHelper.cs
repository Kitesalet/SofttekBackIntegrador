using AutoMapper;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Helpers
{
    public class MapperHelper : Profile
    {
        /// <summary>
        /// Este constructor va a contener la logica de los mapeos Entidad-DTO utilizando la libreria AutoMapper y sus metodos
        /// </summary>
        public MapperHelper() 
        {
            
            CreateMap<Proyecto, ProyectoDTO>().ReverseMap();
            CreateMap<Servicio,ServicioDTO>().ReverseMap();
            CreateMap<Trabajo, TrabajoDTO>().ReverseMap();

            //Mappeo de usuarios a sus respectivos Dtos
            CreateMap<Usuario, UsuarioLoginDto>().ReverseMap();
            CreateMap<Usuario, UsuarioUpdateDto>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateDto>().ReverseMap();


        }

    }
}
