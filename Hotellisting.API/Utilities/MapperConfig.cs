using AutoMapper;
using Hotellisting.API.Data.Models;
using Hotellisting.API.DTOs;
using Hotellisting.API.DTOs.Country;

namespace Hotellisting.API.Utilities
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
        }
    }
}
