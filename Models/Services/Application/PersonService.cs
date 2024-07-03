using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Models.ViewModels;
using People.Models.ValueTypes;

namespace People.Models.Services.Application
{
    public class PersonService
    {
        public List<PersonViewModel> GetPeople()
        {
            var peopleList = new List<PersonViewModel>();
            var rand = new Random();

            for (int i = 1; i <= 20; i++)
            {   
                var garageList = new List<Auto>();
                for (int y = 0; y < 3; y++)
                {   
                    int val = rand.Next(100, 900);
                    garageList.Add(new Auto(
                        $"DW{val}TJ",
                        "BMW",
                        "X4",
                        "NERA"
                    ));

                var person = new PersonViewModel
                {
                    Id = i,
                    Name = "Luca",
                    Surname = "Rossi",
                    Age = rand.Next(18, 90),
                    Garage = garageList
                };
                peopleList.Add(person);
                };
            }
            return peopleList;
        }


    }
}