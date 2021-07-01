using PustokHomework.Models;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }
        public List<Promotion> UpPromotions { get; set; }
        public List<Promotion> DownPromotions { get; set; }
        public List<Book> FeaturedBooks { get; set; }
        public List<Book> NewBooks { get; set; }
        public List<Book> DiscountedBooks { get; set; }
        public List<Book> Childrens { get; set; }
        public List<Book> Arts { get; set; }
        public List<ArtBooksRedirectUrl> ArtRedirectUrls { get; set; }
        public List<Partner> Partners { get; set; }

    }
}
