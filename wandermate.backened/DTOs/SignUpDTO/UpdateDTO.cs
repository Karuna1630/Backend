using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.backened.DTOs.SignUpDTO
{
    public class UpdateDTO
    {
        public string Username {get;set;} = String.Empty;
        public string Email { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;
    }
}