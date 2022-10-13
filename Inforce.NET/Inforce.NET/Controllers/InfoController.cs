using Inforce.NET.BLL;
using Inforce.NET.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly UserService _service;

        public InfoController(UserService service)
        {
            _service = service;
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("urls/{userId}")]
        public async Task<IActionResult> GetUrlsByUserId(int userId)
        {
            var urls = await _service.GetUrlsByUserId(userId);
            return Ok(urls);
        }
    }
}
