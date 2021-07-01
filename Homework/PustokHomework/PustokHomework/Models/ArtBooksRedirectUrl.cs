using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class ArtBooksRedirectUrl
    {
        public int Id { get; set; }

        public string ArtUrl { get; set; }
        public string ArtAuthorUrl { get; set; }
        public List<Book> Books { get; set; }

    }
}
