using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Models.ValueTypes;

namespace People.Models.ViewModels
{
    public class PersonDetailViewModel : PersonViewModel
    {
        public List<Auto> Garage { get ; set; }

    }
}