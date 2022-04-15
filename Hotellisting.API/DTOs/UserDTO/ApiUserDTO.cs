using System.ComponentModel.DataAnnotations;

namespace Hotellisting.API.DTOs.UserDTO
{
    public class ApiUserDTO : LoginDTO
    {
        [Required]
        public string  FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

      
    }
}
