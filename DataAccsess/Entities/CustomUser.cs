using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Entities
{
    public class CustomUser : IdentityUser
    {
        public string? Surname { get; set; } = string.Empty;
        public string? Firstname { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
