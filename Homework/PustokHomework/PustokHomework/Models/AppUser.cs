using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
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
        public bool IsOnline { get; set; }
        public DateTime DIsconnectedAt { get; set; }

        public string ConnectionId { get; set; }

    }
}
