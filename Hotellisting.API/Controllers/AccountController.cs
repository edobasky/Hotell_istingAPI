using Hotellisting.API.Contracts;
using Hotellisting.API.DTOs.UserDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotellisting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AccountController(IAuthManager authManager)
        {
            this._authManager = authManager;
        }


        // POST : api/Account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Register([FromBody] ApiUserDTO apiUserDTO )
        {
            var errors = await _authManager.Register(apiUserDTO);

            if(errors.Any())
            {
                foreach(var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                    
                }
                return BadRequest(ModelState);
            }

            return Ok("User account created!");

        }


        // POST : api/Account/login
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Login([FromBody] ApiUserDTO loginDTO)
        {
            var isValidUser = await _authManager.login(loginDTO);
            
            if(!isValidUser)
            {
                return Unauthorized();
            }

            return Ok("User signed in!");

        }
    }
}
