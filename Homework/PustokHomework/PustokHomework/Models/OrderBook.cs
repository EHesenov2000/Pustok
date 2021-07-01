using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class OrderBook
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? BookId { get; set; }
        public int Count { get; set; }
        [StringLength(maximumLength: 100)]
        public string CategoryName { get; set; }
        [StringLength(maximumLength: 100)]
        public string AuthorName { get; set; }
        [StringLength(maximumLength: 150)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProducingPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}
