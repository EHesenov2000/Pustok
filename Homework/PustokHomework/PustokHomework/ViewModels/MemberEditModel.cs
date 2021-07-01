using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class MemberEditModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }

        [NotMapped]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmedPassword { get; set; }

        [NotMapped]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [StringLength(maximumLength: 300)]
        public string Address { get; set; }
        [StringLength(maximumLength: 20)]
        public string ContactPhone { get; set; }
    }
}
