using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.backened.DTOs.AccountsDTO
{
    public class LoginDTO
    {
        [Required]
         public string UserName{get;set;}= String.Empty;
         [Required]
        public string Password{get;set;} = String.Empty;
    }
}