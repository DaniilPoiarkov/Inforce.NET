﻿using Inforce.NET.BLL.Services;
using Inforce.NET.Common.AuxiliaryModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.NET.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult LoginPage(bool isError = false)
        {
            ViewBag.Error = isError;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPage(UserLogin credentials)
        {
            var user = await _authService.Login(credentials);
            if (user != null)
                return RedirectToAction("Index", "Home");
            return RedirectToAction("LoginPage", new { isError = true });
        }
    }
}
