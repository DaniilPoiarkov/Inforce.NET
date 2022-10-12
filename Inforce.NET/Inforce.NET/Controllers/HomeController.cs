using Inforce.NET.BLL;
using Inforce.NET.BLL.Services;
using Inforce.NET.Common.AuxiliaryModels;
using Inforce.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Inforce.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestService _service;
        private readonly AuthService _authService;

        public HomeController(TestService service, AuthService authService)
        {
            _service = service;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult UserList()
        {
            ViewBag.User = _service.GetTestPlural();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}