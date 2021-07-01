using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 25,ErrorMessage ="max 150 olmalidi")]
        public string FullName { get; set; }
        [StringLength(maximumLength: 500, ErrorMessage = "Max uzunluq 500 ola biler!")]
        public string Desc { get; set; }
        [StringLength(maximumLength:100,ErrorMessage ="max uzunluq 100 ola biler")]
        public string Photo { get; set; }
        public bool? IsDeleted { get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }
        public List<Book> Books { get; set; }


    }
}
