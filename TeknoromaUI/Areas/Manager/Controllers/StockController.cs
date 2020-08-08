using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TeknoromaUI.Areas.Manager.Models.ViewModels;

namespace TeknoromaUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class StockController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public StockController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            ProductVM productVM = new ProductVM();
            productVM.Products = productService.GetActive();
            productVM.Categories = categoryService.GetActive();
            Product product = new Product();
            return View(productVM);
        }

        public IActionResult Create()
        {
            ViewBag.MainCategories = categoryService.GetActive().Select(x => new SelectListItem() { Text = x.CategoryName, Value = x.ID.ToString() });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                productService.Add(product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }
                
           
            
        }

        public IActionResult Edit(Guid id)
        {
            ViewBag.MainCategories = categoryService.GetActive().Select(x => new SelectListItem() { Text = x.CategoryName, Value = x.ID.ToString() });

            return View(productService.GetById(id));
        }
        [HttpPost]
        public async  Task<IActionResult> Edit(Product product)
        {
            try
            {
                productService.Update(product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }
           
        }

        public IActionResult Delete(Guid id)
        {
            return View(productService.GetById(id));
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            try
            {
                productService.Remove(product.ID);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }
        }

       

       
    }
}
