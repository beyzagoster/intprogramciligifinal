using AutoMapper;
using EmlakPortali.API.Dtos;
using EmlakPortali.API.Models;
using EmlakPortali.Dtos;
using EmlakPortali.Models;

namespace EmlakPortali.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<House, Dtos.HouseDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
