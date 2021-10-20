using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Surfbreak.Models.Account;

namespace Surfbreak.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> usermanager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> usermanager, SignInManager<IdentityUser> signInManager)
        {
            this.usermanager = usermanager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await signInManager.PasswordSignInAsync(
                login.EmailAddress, login.Password,
                login.RememberMe, false
            );

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login error!");
                return View();
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await signInManager.SignOutAsync();

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registration)
        {
            if(!ModelState.IsValid)
                return View(registration);

            var newUser = new IdentityUser() 
            { 
                Email = registration.EmailAddress, 
                UserName = registration.EmailAddress 
            };

            var result = await usermanager.CreateAsync(newUser, registration.Password);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors.Select(x=>x.Description))
                {
                    ModelState.AddModelError("", error);
                    
                }
                return View();
            }
            return RedirectToAction("Login");

        }
    }
}
