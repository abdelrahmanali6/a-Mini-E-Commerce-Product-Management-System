using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.Models;

namespace Management_System.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}