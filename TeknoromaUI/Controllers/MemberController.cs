using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeknoromaUI.Models.ViewModels;

namespace TeknoromaUI.Controllers
{
    public class MemberController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppUserRole> roleManager;

        public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppUserRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(loginVM.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, false);
                    if (result.Succeeded)
                    {
                       
                        if (await userManager.IsInRoleAsync(user, "Manager"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Manager" });

                        }
                        if (await userManager.IsInRoleAsync(user,"Case"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Case" });
                        }
                    }
                }
            }

            return View();

        }
    }
} 
