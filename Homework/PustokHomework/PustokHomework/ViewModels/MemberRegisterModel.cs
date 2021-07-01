using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.ViewModels
{
    public class MemberRegisterModel
    {
        [StringLength(maximumLength: 30)]
        public string FullName { get; set; }

        [StringLength(maximumLength: 20)]
        public string UserName { get; set; }

        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmedPassword { get; set; }
    }
}
