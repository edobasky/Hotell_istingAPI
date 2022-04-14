using System.ComponentModel.DataAnnotations;

namespace Hotellisting.API.DTOs.Country
{
    public class BaseCountryDTO
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
