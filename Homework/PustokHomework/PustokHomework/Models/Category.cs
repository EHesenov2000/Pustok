using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class Category
    {
        public int Id{get; set;}
        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public List<Book> Books { get; set; }
    }
}
