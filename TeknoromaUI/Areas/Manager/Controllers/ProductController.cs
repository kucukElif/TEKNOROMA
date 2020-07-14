using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeknoromaUI.Areas.Manager.Models.ViewModels;

namespace TeknoromaUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles ="Manager")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Stock()
        {
            ProductVM productVM = new ProductVM();
            productVM.Products = productService.GetActive();
            productVM.Categories = categoryService.GetActive();
            return View(productVM);
        }
    }
}
