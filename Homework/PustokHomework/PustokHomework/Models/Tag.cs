using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [StringLength(maximumLength:25)]
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public List<BookTag> BookTags { get; set; }

    }
}
