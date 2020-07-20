﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TeknoromaUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View(categoryService.GetActive());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            ViewBag.MainCategories = categoryService.GetActive().Select(x => new SelectListItem() { Text = x.CategoryName, Value = x.ID.ToString() });
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                categoryService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(Guid id)//158yasdghads698
        {
            Category category = categoryService.GetById(id);
            ViewBag.MainCategories = categoryService.GetActive().Select(x => new SelectListItem() { Text = x.CategoryName, Value = x.ID.ToString() });
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Update(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        // GET: Category/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(categoryService.GetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category category)
        {
            try
            {
                categoryService.Remove(category.ID);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
