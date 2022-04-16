using Hotellisting.API.DTOs.UserDTO;
using Microsoft.AspNetCore.Identity;

namespace Hotellisting.API.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDTO userDTO);
        Task<AuthResponseDTO> login(LoginDTO loginDTO);

        Task<string> CreateRefreshToken();
        Task<AuthResponseDTO> VerifyRefreshToken(AuthResponseDTO request); 
    }
}
