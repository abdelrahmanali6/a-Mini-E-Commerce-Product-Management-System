using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management_System.DTOs.Account
{
    public class NewUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid CartItemId { get; set; }

        public string Token { get; set; }
    }
}