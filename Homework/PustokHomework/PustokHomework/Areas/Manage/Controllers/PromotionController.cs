using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PustokHomework.DAL;
using PustokHomework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Areas.Manage.Controllers
{
    [Area("manage")]
    public class PromotionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PromotionController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Promotions.Count() / 4m);
            List<Promotion> promotions = _context.Promotions.Skip((page - 1) * 4).Take(4).ToList();

            return View(promotions);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Promotion promotion)
        {
            if (promotion.PhotoFile != null)
            {
                if (promotion.PhotoFile.ContentType != "image/png" && promotion.PhotoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PhotoFile", "Jpeg ve ya png formatinda data olmalidir.");
                    return View();
                }
                if (promotion.PhotoFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("PhotoFile", "File olcusu 2mb-dan cox olmaz!");
                    return View();
                }

                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + promotion.PhotoFile.FileName;
                var path = Path.Combine(rootPath, "uploads", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    promotion.PhotoFile.CopyTo(stream);
                }
                promotion.Image = fileName;
            }


            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Promotions.Add(promotion);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Promotion promotion = _context.Promotions.FirstOrDefault(x => x.Id == id);

            if (promotion == null)
            {
                return RedirectToAction("index");
            }

            return View(promotion);
        }

        [HttpPost]
        public IActionResult Edit(int id, Promotion promotion)
        {
            Promotion existPromotion = _context.Promotions.FirstOrDefault(x => x.Id == id);

            if (existPromotion == null)
            {
                return RedirectToAction("index");
            }
            if (promotion.PhotoFile != null)
            {

                if (promotion.PhotoFile.ContentType != "image/png" && promotion.PhotoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PhotoFile", "Mime type yanlisdir!");
                    return View();
                }

                if (promotion.PhotoFile.Length > (1024 * 1024) * 2)
                {
                    ModelState.AddModelError("PhotoFile", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View();
                }

                string filename = Guid.NewGuid().ToString() + promotion.PhotoFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "uploads", filename);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    promotion.PhotoFile.CopyTo(stream);
                }

                if (existPromotion.Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads", existPromotion.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }


                existPromotion.Image = filename;
            }

            else if (promotion.Image == null)
            {
                if (existPromotion.Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads", existPromotion.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }

                    existPromotion.Image = null;
                }
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            existPromotion.Title = promotion.Title;
            existPromotion.SubTitle = promotion.SubTitle;
            existPromotion.RedirectUrl = promotion.RedirectUrl;
            existPromotion.LocationStatus = promotion.LocationStatus;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Promotion promotion = _context.Promotions.FirstOrDefault(x => x.Id == id);
            if (promotion == null)
            {
                return RedirectToAction("index");
            }
            //_context.Authors.Remove(author);
            _context.Promotions.Remove(promotion);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
