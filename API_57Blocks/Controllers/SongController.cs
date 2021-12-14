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
        private HttpContext _context;

        public SongController(ISongService songService, HttpContext context)
        {
            _songService = songService;
            _context = context;
        }

        [HttpGet("private")]
        public IActionResult GetPrivate()
        {
            try
            {
                var user = (User)_context.Items["User"];
                if (user == null)
                    return Unauthorized();
                var response = _songService.GetPrivate(user.Id);
                return Ok(response);
            }
            catch (AppException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("public")]
        public IActionResult GetPublic()
        {
            try
            {
                var response = _songService.GetPublic();
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

        [HttpPut]
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