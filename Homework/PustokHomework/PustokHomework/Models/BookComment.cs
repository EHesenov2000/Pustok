using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class BookComment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string AppUserId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }

        [Required]
        [StringLength(maximumLength: 500)]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public Book Book { get; set; }
        public AppUser AppUser { get; set; }
    }
}
