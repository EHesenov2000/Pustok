using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokHomework.DAL;
using PustokHomework.Models;
using PustokHomework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel ViewModel = new HomeViewModel
            {
                Sliders = _context.Sliders.OrderBy(x => x.Order).ToList(),
                Services = _context.Services.OrderBy(x => x.Order).Take(4).ToList(),
                UpPromotions = _context.Promotions.Where(x => x.LocationStatus).ToList(),
                DownPromotions = _context.Promotions.Where(x => x.LocationStatus == false).ToList(),
                FeaturedBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x => x.IsFeatured).Take(12).ToList(),
                NewBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x => x.IsNew).Take(12).ToList(),
                DiscountedBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x => x.DiscountPercent > 0).Take(12).ToList(),
                Childrens = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x => x.IsChildren).Take(24).ToList(),
                Arts = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Include(x => x.ArtBooksRedirectUrl).Where(x => x.IsArt).Take(24).ToList(),
                Partners = _context.Partners.ToList()



            };

            return View(ViewModel);
        }
        public ActionResult GetDetailedBook(int id)
        {
            Book book = _context.Books
                .Include(x => x.Author).Include(x => x.Category).Include(x => x.BookImages)
                .Include(x => x.BookTags).ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.Id == id);

            book.BookImages = book.BookImages.Where(x => x.IsPoster == true).ToList();


            //GetDetailedViewModel bookVM = new GetDetailedViewModel
            //{
            //    DicountedPrice = book.DicountedPrice,
            //    DiscountPercent = book.DiscountPercent,
            //    Name = book.Name,
            //    IsAvailable = book.IsAvailable,
            //    Author = book.Author,
            //    Category = book.Category,
            //    BookTags = book.BookTags,
            //    Code = book.Code,
            //    Price = book.Price,
            //    Rate = book.Rate,
            //    Subtitle = book.Subtitle,
            //    PosterName = book.BookImages.FirstOrDefault(x => x.IsPoster == true).Name
            //};
            return Json(book);
        }
        public ActionResult BookModalPartial(int id)
        {
            Book book = _context.Books
               .Include(x => x.Author).Include(x => x.Category).Include(x => x.BookImages)
               .Include(x => x.BookTags).ThenInclude(x => x.Tag)
               .FirstOrDefault(x => x.Id == id);

            return PartialView("_BookModal", book);
        }



    }
}
