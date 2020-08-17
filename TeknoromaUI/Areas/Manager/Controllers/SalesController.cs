using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeknoromaUI.Areas.Manager.Models.ViewModels;

namespace TeknoromaUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class SalesController : Controller
    {
        private readonly IProductService productService;
        private readonly ICustomerService customerService;
        private readonly IAppUserService appUserService;
        private readonly ICategoryService categoryService;
        private readonly IOrderService orderService;

        public SalesController(IProductService productService, ICustomerService customerService,IAppUserService appUserService, ICategoryService categoryService, IOrderService orderService)
        {
            this.productService = productService;
            this.customerService = customerService;
            this.appUserService = appUserService;
            this.categoryService = categoryService;
            this.orderService = orderService;
        }
        public IActionResult Index()
        {
            SalesVM salesVM = new SalesVM();
            salesVM.Category = categoryService.GetActive();
            salesVM.Customers = customerService.GetActive();
            salesVM.Orders = orderService.GetActive();
            salesVM.Product = productService.GetActive();
            salesVM.AppUser = appUserService.GetActive();
            
            return View(salesVM);
        }
    }
}
