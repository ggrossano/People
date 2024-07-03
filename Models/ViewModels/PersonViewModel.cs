using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Models.ValueTypes;

namespace People.Models.ViewModels
{
    public class PersonViewModel
    {
        public int Id{get;set;} 
        public string Name{get;set;}
        public string Surname{get;set;}
        public int Age{get;set;}
        public List<Auto> Garage{get;set;}

    }
}