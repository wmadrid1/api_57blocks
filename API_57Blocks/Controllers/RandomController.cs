using API_57Blocks.Authorization;
using API_57Blocks.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API_57Blocks.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RandomController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public RandomController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetStringAsync(new Uri(_appSettings.RandomAPI_URL)).Result;
                    return Ok(response);
                }
            }
            catch (AppException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
