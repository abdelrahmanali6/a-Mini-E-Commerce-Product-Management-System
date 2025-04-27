using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Management_System.Models
{
    public class AppUser : IdentityUser
    {
        public Guid CartItemId { get; set; }
    }
}