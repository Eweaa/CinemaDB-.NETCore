using AutoMapper;
using Cinema_DB.Application.Actors.Queries;
using Cinema_DB.Application.Movies.Queries;
using Cinema_DB.Domain.Entities;

namespace Cinema_DB.Helper
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<Movie, MovieDto>()
                .ForMember(des => des.DirectorName, opt => opt.MapFrom(src => src.Director.Id))
                .ForMember(des => des.DirectorName, opt => opt.MapFrom(src => src.Director.Name)).ReverseMap();
                //.ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))

        }
    }
}
