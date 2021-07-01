using PustokHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.ViewModels
{
    public class BookDetailViewModel
    {
        public Book Book { get; set; }
        public List<Book> RelatedBooks { get; set; }
    }
}
