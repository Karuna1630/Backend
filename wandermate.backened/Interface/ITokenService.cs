using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wandermate.backened.Models;

namespace wandermate.backened.Interface
{
    public interface ITokenService// "I" indicaate as interface class
    {
        string CreateToken(AppUser appUser);
    }
}