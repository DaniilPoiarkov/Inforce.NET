using Inforce.NET.BLL;
using Inforce.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Inforce.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestService _service;

        public HomeController(TestService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public new IActionResult User()
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