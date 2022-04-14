namespace Hotellisting.API.DTOs.Country
{
    public class CountryDTO : BaseCountryDTO
    {
        public int Id { get; set; }

        public List<HotelDTO> Hotels { get; set; }
    }
}
