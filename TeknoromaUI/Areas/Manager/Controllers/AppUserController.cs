using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeknoromaUI.Areas.Manager.Models.ViewModels;

namespace TeknoromaUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles ="Manager")]
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppUserRole> roleManager;

        public AppUserController(UserManager<AppUser> userManager, RoleManager<AppUserRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        public async Task<IActionResult> AssignCase(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "Case");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AssignDepot(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "Depot");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AssignManager(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "Manager");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AssignMobile(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "Mobile");
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> AssignSalesman(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "Salesman");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AssignService(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "Service");
            return RedirectToAction("Index");
        }
    }
}
