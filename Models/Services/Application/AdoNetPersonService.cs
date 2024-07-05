using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using People.Models.ViewModels;
using People.Models.ValueTypes;
using People.Models.Services.Infrastructure;
using People.Models.ViewModels.InputModels;

namespace People.Models.Services.Application
{
    public class AdoNetPersonService : IPersonService
    {

        private readonly IDatabaseAccessor db;

        public AdoNetPersonService(IDatabaseAccessor db)
        {
            this.db = db;
        }

        public List<PersonViewModel> GetPeople()
        {
            FormattableString query = $"SELECT Id, Name, Surname, Age FROM Person";

            DataSet dataSet = db.Query(query);

            var dataTable = dataSet.Tables[0];
            var personList = new List<PersonViewModel>();

            foreach (DataRow personRow in dataTable.Rows)
            {
                var person = PersonViewModel.FromDataRow(personRow);
                personList.Add(person);
            }

            return personList;
        }

        public PersonDetailViewModel GetPerson(int id)
        {
            FormattableString query = $@"SELECT * FROM Person WHERE Id = {id}; 
            SELECT * FROM Auto WHERE PersonId = {id}";

            DataSet dataSet = db.Query(query);

            var dataTable = dataSet.Tables[0];
            if (dataTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Nessuna persona trovata con l'id :{id}");
            }
            var personRow = dataTable.Rows[0];
            var person = PersonDetailViewModel.FromDataRow(personRow);

            var carTable = dataSet.Tables[1];
            if (dataTable.Rows.Count == 0)
            {
                throw new InvalidOperationException($"Nessuna macchina trovata per la persona con l'id :{id}");
            }

            foreach (DataRow carRow in carTable.Rows)
            {
                person.Garage.Add(Auto.FromDataRow(carRow));
            }

            return person;
        }

        public PersonDetailViewModel CreatePerson(PersonCreateInputModel input)
        {
            string Name = input.Name;
            string Surname = input.Surname;
            string Age = input.Age;

            var personId = db.QueryInsert($@"INSERT INTO Person (Name, Surname, Age) VALUES ({Name}, {Surname}, {Age});");

            PersonDetailViewModel person = GetPerson(personId);
            return person;
        }

    }
}