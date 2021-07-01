using PustokHomework.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string ContactPhone { get; set; }
        public string Note { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public AppUser AppUser { get; set; }

        public List<OrderBook> OrderBooks { get; set; }
    }
}
