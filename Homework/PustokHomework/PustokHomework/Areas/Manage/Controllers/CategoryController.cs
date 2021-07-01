using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokHomework.DAL;
using PustokHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Categories.Count() / 4m);
            List<Category> categories = _context.Categories.Include(x => x.Books).Skip((page - 1) * 4).Take(4).ToList();

            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            category.IsDeleted = false;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return RedirectToAction("index");
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            Category existcategory = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (existcategory == null)
            {
                return RedirectToAction("index");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            existcategory.Name = category.Name;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return RedirectToAction("index");
            }
            category.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Restore(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null) return RedirectToAction("index");

            category.IsDeleted = false;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
