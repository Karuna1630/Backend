using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.backened.DTOs.TravelPackagesDTO
{
    [Table("TravelPackages")]
  
    public class TravelPackagesDTO
    {
         
        public int Id{get;set;}

        public string Title{get;set;} = String.Empty;
        public string Weather{get;set;} = String.Empty;
        public List<string> Image{get;set;}= new List<string>();

        public string Description{get;set;} = String.Empty;
    }
}
