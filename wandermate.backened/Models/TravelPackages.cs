using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace wandermate.backened.Models
{
    [Table("TravelPackages")]
    public class TravelPackages
    {
        [Key]
        public int Id{get;set;}

        public string Title{get;set;} = String.Empty;
        public string Weather{get;set;} = String.Empty;
        public List<string> Image{get;set;}= new List<string>();

        public string Description{get;set;} = String.Empty;
    }
}