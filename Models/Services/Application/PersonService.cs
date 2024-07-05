using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Models.ViewModels;
using People.Models.ValueTypes;
using People.Models.ViewModels.InputModels;

namespace People.Models.Services.Application
{
    public class PersonService : IPersonService
    {
        public List<PersonViewModel> GetPeople()
        {
            var rand = new Random();

            var peopleList = new List<PersonViewModel>();

            for (int i = 1; i <= 20; i++)
            {
                var person = new PersonViewModel
                {
                    Id = i,
                    Name = "Luca",
                    Surname = "Rossi",
                    Age = rand.Next(18, 90)
                };
                peopleList.Add(person);
            };

            return peopleList;

        }

        public PersonDetailViewModel GetPerson(int id)
        {
            var rand = new Random();

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
            };

            var person = new PersonDetailViewModel
            {
                Id = id,
                Garage = garageList
            };

            return person;
        }

        public PersonDetailViewModel CreatePerson(PersonCreateInputModel input)
        {
            throw new NotImplementedException();
        }

    }
}