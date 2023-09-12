using AutoMapper;
using IntegradorSofttekImanol.DTOs;
using IntegradorSofttekImanol.Entities;

namespace IntegradorSofttekImanol.Helpers
{
    public class Mapper : Profile
    {
        /// <summary>
        /// Este constructor va a contener la logica de los mapeos Entidad-DTO utilizando la libreria AutoMapper y sus metodos
        /// </summary>
        public Mapper() 
        {
            
            CreateMap<Proyecto, ProyectoDTO>().ReverseMap();
            CreateMap<Servicio,ServicioDTO>().ReverseMap();
            CreateMap<Trabajo, TrabajoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        
        }

    }
}
