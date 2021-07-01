using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class Service
    {
        public int Id { get; set; }

        [StringLength(maximumLength:100)]
        public string Title { get; set; }
        
        [StringLength(maximumLength:100)]
        public string SubTitle { get; set; }

        [StringLength(maximumLength: 50)]
        public string Icon { get; set; }
        public bool? IsDeleted { get; set; }
        public int Order { get; set; }
    }
}
