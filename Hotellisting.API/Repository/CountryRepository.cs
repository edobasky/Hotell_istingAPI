using AutoMapper;
using Hotellisting.API.Contracts;
using Hotellisting.API.Data;
using Hotellisting.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotellisting.API.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper mapper;

        public CountryRepository(HotelListingDbContext context,IMapper mapper) : base(context,mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        public Task<Country> GetDetails(int id)
        {
            return _context.Countries.Include(p => p.Hotels).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
