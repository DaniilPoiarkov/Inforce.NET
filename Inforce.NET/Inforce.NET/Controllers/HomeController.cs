using Inforce.NET.BLL.Interfaces;
using Inforce.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Inforce.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _service;
        private readonly IAuthService _authService;

        public HomeController(IUserService service, IAuthService authService)
        {
            _service = service;
            _authService = authService;
        }

        public async Task<IActionResult> Index(int? id = null)
        {
            ViewBag.Id = id;

            if(id != null)
            {
                var user = await _service.GetUserById((int)id);
                ViewBag.Name = user.FullName;
                ViewBag.User = user;
            }

            return View();
        }

        public async Task<IActionResult> About(int? id = null)
        {
            ViewBag.Id = id;

            if (id != null)
            {
                var user = await _service.GetUserById((int)id);
                ViewBag.Name = user.FullName;
                ViewBag.User = user;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}