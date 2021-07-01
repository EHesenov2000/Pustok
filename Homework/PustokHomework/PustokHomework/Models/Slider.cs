using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }

        [StringLength(maximumLength: 100)]
        public string Title { get; set; }

        [StringLength(maximumLength: 250)]
        public string Subtitle { get; set; }

        [StringLength(maximumLength: 10)]
        public string Price { get; set; }

        [StringLength(maximumLength: 250)]
        public string RedirectUrl { get; set; }
        public int Order { get; set; }
    }
}
