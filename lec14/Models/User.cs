using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lec14.Models
{
    public partial class User
    {
        [Key]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public Profile Profile { get; set; }

    }
}