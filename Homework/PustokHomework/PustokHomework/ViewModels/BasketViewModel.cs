using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class BasketViewModel
    {
        //public List<BasketItemViewModel> BasketItems { get; set; }
        public List<BookBasketItem> BookItems { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class BookBasketItem
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
