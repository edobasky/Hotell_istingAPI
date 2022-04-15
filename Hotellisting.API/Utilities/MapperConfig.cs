using AutoMapper;
using Hotellisting.API.Data.Models;
using Hotellisting.API.DTOs;
using Hotellisting.API.DTOs.Country;
using Hotellisting.API.DTOs.UserDTO;

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

            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();

            CreateMap<ApiUserDTO, ApiUser>().ReverseMap();
        }
    }
}
