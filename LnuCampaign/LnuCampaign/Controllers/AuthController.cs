using System.Threading.Tasks;
using LnuCampaign.Core.Data.Dto;
using LnuCampaign.Core.Interfaces.Services;
using LnuCampaign.Core.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog.Core;
using LnuCampaign.Configuration;
using System;

namespace LnuCampaign.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private readonly Logger _logger;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            _logger = LoggerConfig.ConfigureLogger();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                model.Role = Roles.User;
                try
                {
                    var resultOfCreation = await _authService.CreateUserAsync(model);
                
                if (resultOfCreation.Succeeded)
                {
                    var resultOfSignIn = await _authService.SignInAsync(new LoginDto()
                    { Email = model.Email, Password = model.Password, RememberMe = false });
                    if (resultOfSignIn.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message);
                }

                ModelState.AddModelError("", "Invalid login or password");
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.SignInAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login or password");
            }
            return View(model);
        }

    }
}
