﻿using AuthenticationAndAuthorization.Models.DTOs;
using AuthenticationAndAuthorization.Models.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationAndAuthorization.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }

        #region Registration
        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser { UserName = model.UserName, Email = model.Email };

                IdentityResult idendityResult = await _userManager.CreateAsync(appUser, model.Password);

                if (idendityResult.Succeeded)
                    return RedirectToAction("Login");
                else
                    foreach (IdentityError error in idendityResult.Errors)
                        ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        #endregion

        #region Login
        [AllowAnonymous]
        public IActionResult LogIn(string returnUrl)
        {
            return View(new LoginDTO { ReturnUrl = returnUrl });
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> LogIn(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByNameAsync(model.UserName);

                if (appUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult singInResult = await _signInManager.PasswordSignInAsync(appUser.UserName, model.Password, false, false);

                    if (singInResult.Succeeded) return Redirect(model.ReturnUrl ?? "/");

                    ModelState.AddModelError("","Wrong credation information..!");
                }
            }
            return View(model);
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
