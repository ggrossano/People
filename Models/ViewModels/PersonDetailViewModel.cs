using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using People.Models.ValueTypes;

namespace People.Models.ViewModels
{
    public class PersonDetailViewModel : PersonViewModel
    {
        public List<Auto> Garage { get; set; }


        public static PersonDetailViewModel FromDataRow(DataRow row)
        {
            var person = new PersonDetailViewModel
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = Convert.ToString(row["Name"]),
                Surname = Convert.ToString(row["Surname"]),
                Age = Convert.ToInt32(row["Age"]),
                Garage = new List<Auto>()
            };

            return person;
        }

    }
}