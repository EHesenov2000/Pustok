using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string HeaderLogo { get; set; }

        [StringLength(maximumLength: 150)]
        public string Address { get; set; }

        [StringLength(maximumLength: 25)]
        public string SupportPhone { get; set; }
        [StringLength(maximumLength: 25)]
        public string ContactPhone { get; set; }
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
        [StringLength(maximumLength: 100)]
        public string FooterLogo { get; set; }
    }
}
