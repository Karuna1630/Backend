using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace wandermate.backened.DTOs.HotelDTO
{
   
    public class LoginDTO
    {
        public string Username{get;set;}= String.Empty;
        public string Password{get;set;} = String.Empty;
    }
}