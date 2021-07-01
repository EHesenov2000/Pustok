using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PustokHomework.DAL;
using PustokHomework.Models;
using PustokHomework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Services
{
    public class LayoutViewModelService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public LayoutViewModelService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public Setting GetSetting() {
            return _context.Settings.FirstOrDefault();
        }
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        public List<BasketItemViewModel> GetBasketItems()
        {
            List<BasketItemViewModel> basketItems = new List<BasketItemViewModel>();
            var basketItemsStr = _contextAccessor.HttpContext.Request.Cookies["basket"];

            if (basketItemsStr != null)
            {
                basketItems = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemsStr);
            }

            foreach (var item in basketItems)
            {
                Book bk = _context.Books.FirstOrDefault(x => x.Id == item.Id);
                decimal salePrice = bk.DiscountPercent > 0 ? bk.Price * (100 - bk.DiscountPercent) / 100 : bk.Price;
                item.TotalPrice = salePrice * item.Count;
            }

            return basketItems;
        }
    }
}
