using Inforce.NET.BLL.Interfaces;
using Inforce.NET.Common.AuxiliaryModels;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
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

        [HttpGet("url/{id}")]
        public async Task<IActionResult> GetLinkById(int id)
        {
            var url = await _service.GetUrlById(id);
            return Ok(url);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewShortedUrl(NewUrl model)
        {
            var url = await _service.CreateShortedUrl(model);
            return Ok(url);
        }

        [HttpGet("tiny/{tinyUrl}")]
        public async Task<IActionResult> GetLinkByTinyUrl(string tinyUrl)
        {
            var url = await _service.GetLinkByTinyUrl(tinyUrl);
            return Ok(url);
        }

        [HttpDelete("deleteLink/{id}")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            await _service.DeleteLink(id);
            return NoContent();
        }
    }
}
