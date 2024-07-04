using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using People.Models.ValueTypes;


namespace People.Models.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public static PersonViewModel FromDataRow(DataRow row)
        {
            var person = new PersonViewModel
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = Convert.ToString(row["Name"]),
                Surname = Convert.ToString(row["Surname"]),
                Age = Convert.ToInt32(row["Age"])
            };

        return person;
        }

    }
}