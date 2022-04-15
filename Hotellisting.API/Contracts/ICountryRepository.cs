using Hotellisting.API.Data.Models;

namespace Hotellisting.API.Contracts
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
