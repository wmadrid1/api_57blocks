using API_57Blocks.Authorization;
using API_57Blocks.Helpers;
using API_57Blocks.Models.Users;
using API_57Blocks.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_57Blocks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            try
            {
                var response = _userService.Authenticate(model);
                return Ok(response);
            }
            catch (AppException e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            try
            {
                _userService.Register(model);
                return Ok(new { message = "Registration successful" });
            }
            catch (AppException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}