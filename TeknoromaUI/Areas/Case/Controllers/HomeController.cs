using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TeknoromaUI.Areas.Case.Models;
using TeknoromaUI.Models.ViewModels;

namespace TeknoromaUI.Areas.Case.Controllers
{
    [Area("Case")]
    [Authorize(Roles ="Case")]
    public class HomeController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ICustomerService customerService;
        private readonly ICustomerDataService customerDataService;

        public HomeController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomerService customerService, ICustomerDataService customerDataService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.customerService = customerService;
            this.customerDataService = customerDataService;
        }
        public IActionResult Index()
        {
            return View(customerService.GetActive());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerService.Add(customer);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult GetCustomerByTC()
        {

            return View();
        }
        [HttpPost]
        public IActionResult GetCustomerByTC(Customer customer)
        {
            if (ModelState.IsValid)
            {
               var c = customerService.GetByTc(customer);
               
                    if (c != null)

                {
                    TempData["customer"] = JsonConvert.SerializeObject(c);

                    return RedirectToAction("GetCustomer");
                  


                }
            }

            return View();
        }
       
        public IActionResult GetCustomer(Customer customer)
        {
            ViewData["customer"] = JsonConvert.DeserializeObject<Customer>((string)TempData["customer"]);
            var customerData = ViewData["customer"] as Customer;
            customer = ViewData["customer"] as Customer;
            return View(customer);
        }
        public IActionResult Edit(Guid id)
        {
            Customer customer = customerService.GetById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerService.Update(customer);
                TempData["customer"] = JsonConvert.SerializeObject(customer);
                return RedirectToAction("GetCustomer");

            }
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            return View(customerService.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            try
            {
                customerService.Remove(customer.ID);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
        public async Task<IActionResult> LogOut()
        {
          await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Member", new { area = "" });
        }
    }
}
