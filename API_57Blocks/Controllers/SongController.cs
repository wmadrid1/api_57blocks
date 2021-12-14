using API_57Blocks.Authorization;
using API_57Blocks.Entities;
using API_57Blocks.Helpers;
using API_57Blocks.Models.Songs;
using API_57Blocks.Models.Users;
using API_57Blocks.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_57Blocks.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private ISongService _songService;
        private HttpContext? _context;

        public SongController(ISongService songService, IHttpContextAccessor httpContextAccessor)
        {
            _songService = songService;
            _context = httpContextAccessor.HttpContext;
        }

        [HttpGet("private")]
        public IActionResult GetPrivate([FromQuery] SongsParameters parameters)
        {
            try
            {
                User user = (User)_context.Items["User"];
                if (user == null)
                    return Unauthorized();
                var response = _songService.GetPrivate(user.Id, parameters);
                return Ok(response);
            }
            catch (AppException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("public")]
        public IActionResult GetPublic([FromQuery] SongsParameters parameters)
        {
            try
            {
                var response = _songService.GetPublic(parameters);
                return Ok(response);
            }
            catch (AppException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] SongRequest model)
        {
            try
            {
                var user = (User)_context.Items["User"];
                if (user == null)
                    return Unauthorized();
                var response = _songService.Create(user.Id, model);
                return Ok(response);
            }
            catch (AppException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SongRequest model)
        {
            try
            {
                var user = (User)_context.Items["User"];
                if (user == null)
                    return Unauthorized();
                var response = _songService.Update(user.Id, id, model);
                return Ok(response);
            }
            catch (AppException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}