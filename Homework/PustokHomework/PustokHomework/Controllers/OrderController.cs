using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pustok.ViewModels;
using PustokHomework.DAL;
using PustokHomework.Models;
using PustokHomework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public OrderController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Checkout()
        {
            List<BookBasketItem> cookieBasketItems = new List<BookBasketItem>();
            List<BasketItemViewModel> basketItems = new List<BasketItemViewModel>();

            if (HttpContext.Request.Cookies["basket"] != null)
            {
                cookieBasketItems = JsonConvert.DeserializeObject<List<BookBasketItem>>(HttpContext.Request.Cookies["basket"]);

                foreach (var item in cookieBasketItems)
                {
                    Book book = _context.Books.FirstOrDefault(x => x.Id == item.Id);
                    BasketItemViewModel basketItem = new BasketItemViewModel
                    {
                        Id = book.Id,
                        Count = item.Count,
                        Code = book.Code,
                        Name = book.Name,
                        Price = book.DiscountPercent > 0 ? book.Price * (100 - book.DiscountPercent) / 100 : book.Price,
                    };
                    basketItem.TotalPrice = basketItem.Price * basketItem.Count;

                    basketItems.Add(basketItem);
                }
            }


            ViewBag.IsAuthenticated = false;
            if (User.Identity.IsAuthenticated)
            {
                if (_userManager.Users.Any(x => x.UserName == User.Identity.Name && !x.IsAdmin))
                {
                    ViewBag.IsAuthenticated = true;
                }
            }

            return View(basketItems);
        }


        [HttpPost]
        public IActionResult Create(Order order)
        {
            AppUser user = null;
            if (User.Identity.IsAuthenticated)
            {
                user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (user == null)
            {
                ViewBag.IsAuthenticated = false;

                if (string.IsNullOrWhiteSpace(order.FullName) || string.IsNullOrWhiteSpace(order.ContactPhone) || string.IsNullOrWhiteSpace(order.Address))
                {
                    ModelState.AddModelError("", "FullName, ContactPhone ve Address deyerleri gonderilmelidir!");
                    return View("Checkout", _getBasketItems());
                }
            }
            else
            {
                order.FullName = user.FullName;
                order.Address = user.Address;
                order.ContactPhone = user.ContactPhone;
            }


            List<BookBasketItem> cookieBasketItems = new List<BookBasketItem>();
            cookieBasketItems = JsonConvert.DeserializeObject<List<BookBasketItem>>(HttpContext.Request.Cookies["basket"]);
            if (cookieBasketItems!=null)
            {
                order.OrderBooks = new List<OrderBook>();
                order.Status = Enums.OrderStatus.Pending;
                order.CreatedAt = DateTime.UtcNow;
                order.AppUserId = user != null ? user.Id : null;


                foreach (var item in cookieBasketItems)
                {
                    Book book = _context.Books.Include(x => x.Author).Include(x => x.Category).FirstOrDefault(x => x.Id == item.Id);
                    OrderBook orderItem = new OrderBook
                    {
                        BookId = book.Id,
                        Count = item.Count,
                        SalePrice = book.Price,
                        CategoryName = book.Category.Name,
                        AuthorName = book.Author.FullName,
                        ProducingPrice = book.ProducingPrice,
                        Name = book.Name,
                        Price = book.DiscountPercent > 0 ? book.Price * (100 - book.DiscountPercent) / 100 : book.Price,
                    };
                    orderItem.TotalPrice = orderItem.Price * orderItem.Count;
                    order.OrderBooks.Add(orderItem);

                    order.TotalPrice += orderItem.TotalPrice;
                }
            }
           

            _context.Orders.Add(order);
            _context.SaveChanges();

            HttpContext.Response.Cookies.Delete("basket");
            return RedirectToAction("index", "home");
        }

        public IActionResult Index()
        {
            return View();
        }

        private List<BasketItemViewModel> _getBasketItems()
        {
            List<BookBasketItem> cookieBasketItems = new List<BookBasketItem>();
            cookieBasketItems = JsonConvert.DeserializeObject<List<BookBasketItem>>(HttpContext.Request.Cookies["basket"]);
            List<BasketItemViewModel> basketItems = new List<BasketItemViewModel>();
            if (cookieBasketItems!=null)
            {
                
                foreach (var item in cookieBasketItems)
                {
                    Book book = _context.Books.FirstOrDefault(x => x.Id == item.Id);
                    BasketItemViewModel basketItem = new BasketItemViewModel
                    {
                        Id = book.Id,
                        Count = item.Count,
                        Code = book.Code,
                        Name = book.Name,
                        Price = book.DiscountPercent > 0 ? book.Price * (100 - book.DiscountPercent) / 100 : book.Price,
                    };
                    basketItem.TotalPrice = basketItem.Price * basketItem.Count;

                    basketItems.Add(basketItem);
                }
            }
            

            return basketItems;
        }
    }
}
