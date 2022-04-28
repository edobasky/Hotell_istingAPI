using AutoMapper;
using Hotellisting.API.Contracts;
using Hotellisting.API.Data;
using Hotellisting.API.Data.Models;

namespace Hotellisting.API.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
