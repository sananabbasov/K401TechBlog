using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechBlog.WebUI.DTOs;
using TechBlog.WebUI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechBlog.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AuthController(UserManager<User> userManager, SignInManager<User> singInManager)
        {
            _userManager = userManager;
            _signInManager = singInManager;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var findUser = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (findUser == null)
            {
                return RedirectToAction("Login");
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(findUser,loginDTO.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }

            return View(loginDTO);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            User user = new()
            {
                FirstName = registerDTO.FirstName,
                LastName =  registerDTO.LastName,
                PhotoUrl = "/image/avatar.png",
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(registerDTO);
        }

    }
}

