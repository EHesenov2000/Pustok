using Microsoft.AspNetCore.Mvc;
using PustokHomework.DAL;
using PustokHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Services.Count() / 4m);
            List<Service> services = _context.Services.Skip((page - 1) * 4).Take(4).ToList();

            return View(services);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            service.IsDeleted = false;
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);

            if (service == null)
            {
                return RedirectToAction("index");
            }

            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(int id, Service service)
        {
            Service existService = _context.Services.FirstOrDefault(x => x.Id == id);

            if (existService == null)
            {
                return RedirectToAction("index");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            existService.Title = service.Title;
            existService.SubTitle = service.SubTitle;
            existService.Order = service.Order;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return RedirectToAction("index");
            }
            service.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Restore(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);

            if (service == null) return RedirectToAction("index");

            service.IsDeleted = false;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
