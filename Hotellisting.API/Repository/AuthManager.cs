using AutoMapper;
using Hotellisting.API.Contracts;
using Hotellisting.API.Data.Models;
using Hotellisting.API.DTOs.UserDTO;
using Microsoft.AspNetCore.Identity;

namespace Hotellisting.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public async Task<bool> login(LoginDTO loginDTO)
        {
            bool IsValidUser = false;

            try
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);
                IsValidUser = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            }
            catch (Exception)
            {

                throw;
            }
            return IsValidUser;
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDTO userDTO)
        {
            var user = _mapper.Map<ApiUser>(userDTO);
            user.UserName = userDTO.Email;

            var result = await _userManager.CreateAsync(user);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors;
        }
    }
}
