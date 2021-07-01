using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Sliders.Count() / 4m);
            List<Slider> sliders = _context.Sliders.Skip((page - 1) * 4).Take(4).ToList();

            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider.PhotoFile != null)
            {
                if (slider.PhotoFile.ContentType != "image/png" && slider.PhotoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PhotoFile", "Jpeg ve ya png formatinda data olmalidir.");
                    return View();
                }
                if (slider.PhotoFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("PhotoFile", "File olcusu 2mb-dan cox olmaz!");
                    return View();
                }

                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + slider.PhotoFile.FileName;
                var path = Path.Combine(rootPath, "uploads", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.PhotoFile.CopyTo(stream);
                }
                slider.Image = fileName;
            }


            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (slider == null)
            {
                return RedirectToAction("index");
            }

            return View(slider);
        }

        [HttpPost]
        public IActionResult Edit(int id, Slider slider)
        {
            Slider existSlider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (existSlider == null)
            {
                return RedirectToAction("index");
            }
            if (slider.PhotoFile != null)
            {

                if (slider.PhotoFile.ContentType != "image/png" && slider.PhotoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PhotoFile", "Mime type yanlisdir!");
                    return View();
                }

                if (slider.PhotoFile.Length > (1024 * 1024) * 2)
                {
                    ModelState.AddModelError("PhotoFile", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View();
                }

                string filename = Guid.NewGuid().ToString() + slider.PhotoFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "uploads", filename);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.PhotoFile.CopyTo(stream);
                }

                if (existSlider.Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads", existSlider.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }


                existSlider.Image = filename;
            }

            else if (slider.Image == null)
            {
                if (existSlider.Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads", existSlider.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }

                    existSlider.Image = null;
                }
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            existSlider.Title = slider.Title;
            existSlider.Subtitle = slider.Subtitle;
            existSlider.Price = slider.Price;
            existSlider.Order = slider.Order;
            existSlider.RedirectUrl = slider.RedirectUrl;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null)
            {
                return RedirectToAction("index");
            }
            //_context.Authors.Remove(author);
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
