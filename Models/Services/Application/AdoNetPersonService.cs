using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using People.Models.ViewModels;
using People.Models.Services.Infrastructure;


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
            string query = "SELECT Id, Name, Surname, Age FROM Person";

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
            throw new NotImplementedException();

            /* string query = "SELECT * FROM Auto WHERE Id = PersonId";

            DataSet dataSet = db.Query(query);

            var dataTable = dataSet.Tables[0];
            var personList = new List<PersonViewModel>();

            foreach (DataRow personRow in dataTable.Rows)
            {
                var person = PersonViewModel.FromDataRow(personRow);
                personList.Add(person);
            }

            return personList; */
        }

    }
}