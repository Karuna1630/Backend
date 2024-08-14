using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.backened.DTOs.AccountsDTO
{
    public class NewUserDTO
    {
        public string UserName{get;set;}

        public string Email{get;set;}
        public string Token{get;set;}
        public string UserId{get;set;}
    }
}