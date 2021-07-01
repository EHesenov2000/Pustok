using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokHomework.DAL;
using PustokHomework.Helpers;
using PustokHomework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="Admin")]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BookController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Books.Count() / 4m);
            List<Book> books = _context.Books.Include(x=>x.Author).Skip((page - 1) * 4).Take(4).ToList();
            return View(books);
        }
        public IActionResult Create()
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Book book)
        {

            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            if (_context.Authors.Any(x=>x.Id==book.AuthorId))
            {
                ModelState.AddModelError("AuthorId", "Xetaniz var!");
            }
            if (_context.Categories.Any(x => x.Id == book.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Xetaniz var!");
            }
            if (ModelState.IsValid)
            {
                return View();
            }
            if (book.PosterPhoto!=null)
            {
                if (book.PosterPhoto.ContentType != "image/png" && book.PosterPhoto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterPhoto", "Mime type yanlisdir!");
                    return View();
                }

                if (book.PosterPhoto.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("PosterPhoto", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View();
                }

               string fileName= FileManager.Save(_env.WebRootPath,"uploads",book.PosterPhoto);

                BookImage bookImage = new BookImage
                {
                    Book = book,
                    IsHoverPoster = false,
                    IsPoster = true,
                    Image = fileName
                };
                _context.BookImages.Add(bookImage);
            }
            if (book.HoverPosterPhoto != null)
            {
                if (book.HoverPosterPhoto.ContentType != "image/png" && book.HoverPosterPhoto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HoverPosterPhoto", "Mime type yanlisdir!");
                    return View();
                }

                if (book.HoverPosterPhoto.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("HoverPosterPhoto", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View();
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads", book.HoverPosterPhoto);

                BookImage bookImage = new BookImage
                {
                    Book = book,
                    IsHoverPoster = true,
                    IsPoster = false,
                    Image = fileName
                };
                _context.BookImages.Add(bookImage);
            }



            foreach (var item in book.Photos)
            {
                if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("photos", "Mime type yanlisdir!");
                    return View();
                }

                if (item.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("photos", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View();
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads", item);

                BookImage bookImage = new BookImage
                {
                    Book = book,
                    IsHoverPoster = false,
                    IsPoster = false,
                    Image = fileName
                };
                _context.BookImages.Add(bookImage);
            }


            if (book.DiscountPercent>0m)
            {
                book.DicountedPrice = (decimal)book.Price * (100 - book.DiscountPercent) / 100;
            }
            book.CreatedAt = DateTime.UtcNow;




            if (book.TagIds != null)
            {
                foreach (var tagId in book.TagIds)
                {
                    BookTag bookTag = new BookTag
                    {
                        Book = book,
                        TagId = tagId
                    };
                    //book.BookTags.Add(bookTag);
                    _context.BookTags.Add(bookTag);
                }
            }

            book.IsDeleted = false;
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            Book book = _context.Books.Include(x => x.BookTags).Include(x => x.BookImages).FirstOrDefault(x => x.Id == id);

            if (book == null) return RedirectToAction("index");



            return View(book);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            Book existBook = _context.Books.Include(x => x.BookImages).FirstOrDefault(x => x.Id == id);

            if (existBook == null) return RedirectToAction("index");

            if (!_context.Authors.Any(x => x.Id == book.AuthorId)) return RedirectToAction("index");

            if (!_context.Categories.Any(x => x.Id == book.CategoryId)) return RedirectToAction("index");


            existBook.Name = book.Name;
            existBook.DiscountPercent = book.DiscountPercent;
            existBook.Price = book.Price;
            existBook.ProducingPrice = book.ProducingPrice;
            existBook.Subtitle = book.Subtitle;
            existBook.Desc = book.Desc;
            existBook.Code = book.Code;
            existBook.IsAvailable = book.IsAvailable;
            existBook.IsNew = book.IsNew;
            existBook.IsFeatured = book.IsFeatured;
            existBook.CategoryId = book.CategoryId;
            existBook.AuthorId = book.AuthorId;

            if (book.DiscountPercent > 0)
            {
                existBook.DicountedPrice = existBook.Price * (100 - book.DiscountPercent) / 100;
            }
            else
            {
                existBook.DicountedPrice = 0;
            }

            if (book.PosterPhoto != null)
            {
                if (book.PosterPhoto.ContentType != "image/png" && book.PosterPhoto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterPhoto", "Mime type yanlisdir!");
                    return View(existBook);
                }

                if (book.PosterPhoto.Length > (1024 * 1024) * 2)
                {
                    ModelState.AddModelError("PosterPhoto", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View(existBook);
                }

                string filename = FileManager.Save(_env.WebRootPath, "uploads", book.PosterPhoto);

                BookImage poster = _context.BookImages.FirstOrDefault(x => x.BookId == id && x.IsPoster);

                if (poster != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads", poster.Image);

                    poster.Image = filename;
                }
                else
                {
                    poster = new BookImage
                    {
                        BookId = id,
                        IsHoverPoster = false,
                        IsPoster = true,
                        Image = filename
                    };

                    _context.BookImages.Add(poster);
                }
            }
            else if (book.PosterId == null)
            {
                BookImage poster = _context.BookImages.FirstOrDefault(x => x.BookId == id && x.IsPoster);

                if (poster != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads", poster.Image);
                    _context.BookImages.Remove(poster);
                }
            }

            if (book.Photos != null)
            {
                foreach (var item in book.Photos)
                {
                    if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("Photos", "Mime type yanlisdir!");
                        return View(book);
                    }

                    if (item.Length > (1024 * 1024) * 2)
                    {
                        ModelState.AddModelError("Photos", "Faly olcusu 2MB-dan cox ola bilmez!");
                        return View(book);
                    }

                    string filename = FileManager.Save(_env.WebRootPath, "uploads", item);

                    BookImage poster = new BookImage
                    {
                        BookId = id,
                        IsHoverPoster = false,
                        IsPoster = false,
                        Image = filename
                    };

                    _context.BookImages.Add(poster);

                }

            }

            List<BookImage> existBookImages = _context.BookImages.Where(b => b.BookId == book.Id && !b.IsHoverPoster && !b.IsPoster).ToList();
            if (existBookImages != null)
            {
                foreach (var item in existBookImages)
                {
                    if (book.PhotosId!=null)
                    {
                        if (!book.PhotosId.Contains(item.Id))
                        {
                            _context.BookImages.Remove(item);
                        }
                    }   

                }
            }





            var existTags = _context.BookTags.Where(x => x.BookId == id).ToList();
            if (book.TagIds != null)
            {
                foreach (var tagId in book.TagIds)
                {
                    var existTag = existTags.FirstOrDefault(x => x.TagId == tagId);
                    if (existTag == null)
                    {
                        BookTag bookTag = new BookTag
                        {
                            BookId = id,
                            TagId = tagId
                        };
                        _context.BookTags.Add(bookTag);
                    }
                    else
                    {
                        existTags.Remove(existTag);
                    }
                }

            }

            _context.BookTags.RemoveRange(existTags);








            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Bilinmedik bir xeta bas verdi");
                return View(existBook);
            }

            return RedirectToAction("index");
        }
    }
}
