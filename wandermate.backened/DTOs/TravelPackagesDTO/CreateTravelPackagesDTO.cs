using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.backened.DTOs.TravelPackagesDTO
{
    public class CreateTravelPackagesDTO
    {
        public string Title{get;set;} = String.Empty;
        public string Weather{get;set;} = String.Empty;
        public List<string> Image{get;set;}= new List<string>();

        public string Description{get;set;} = String.Empty;
    }
}