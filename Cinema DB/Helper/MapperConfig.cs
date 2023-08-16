using AutoMapper;
using Cinema_DB.Domain.Entities;
using Cinema_DB.Helper.ViewModels;

namespace Cinema_DB.Helper
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Actor, ActorVM>().ReverseMap();
            CreateMap<Movie, MovieVM>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.DirectorName, opt => opt.MapFrom(src => src.Director.Name)).ReverseMap();

        }
    }
}
