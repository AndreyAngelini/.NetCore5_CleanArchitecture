using CleanArch.Domain.Account;
using CleanArch.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authentication;
        public AccountController(IAuthenticate authentication)
        {
            _authentication = authentication;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            var result = await _authentication.RegusterUser(register.Email, register.Password);
            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(register);
            }
        }

        [HttpGet]
        public IActionResult Login(string returnurl)
        {
            return View(new LoginViewModel() { 
                ReturnUrl = returnurl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var result = await _authentication.Authenticate(login.Email, login.Password);
            if(result)
            {
                if(string.IsNullOrEmpty(login.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(login.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(login);
            }            
        }

        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return View();
        }
    }
}
