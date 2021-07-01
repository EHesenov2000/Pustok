using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PustokHomework.DAL;
using PustokHomework.Enums;
using PustokHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<PustokHub> _hub;
        public OrderController(AppDbContext context,IHubContext <PustokHub> hub)
        {
            _context = context;
            _hub = hub;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Books.Count() / 5m);

            var model = _context.Orders.Include(x => x.OrderBooks).OrderByDescending(x => x.CreatedAt).Skip((page - 1) * 5).Take(5).ToList();

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            Order order = _context.Orders.Include(x => x.OrderBooks).FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return RedirectToAction("index");
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult ChangeStatus(int id, OrderStatus status)
        //{
        //    Order order = _context.Orders.FirstOrDefault(x => x.Id == id);

        //    if (order == null)
        //    {
        //        return RedirectToAction("index");
        //    }

        //    order.Status = status;

        //    _context.SaveChanges();

        //    return RedirectToAction("index");
        //}

        public IActionResult ChangeStatus(int id, OrderStatus status, string userId)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return RedirectToAction("index");
            }



            //-------------------------------------
            if (order.Status!=status)
            {

                _hub.Clients.Client(_context.Users.FirstOrDefault(x => x.Id == order.AppUserId).ConnectionId).SendAsync("ShowToastr",status.ToString());

            }



            //-------------------------------------
            order.Status = status;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
