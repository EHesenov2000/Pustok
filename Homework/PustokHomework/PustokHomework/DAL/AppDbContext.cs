using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PustokHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<ArtBooksRedirectUrl> ArtUrls { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<BookComment> BookComments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }
    }
}
