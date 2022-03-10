using RestAPIWithASPNET.Business.Implementations;
using RestAPIWithASPNET.Data.Adapter.Imprementations;
using RestAPIWithASPNET.Data.DTO;
using RestAPIWithASPNET.Model;
using RestAPIWithASPNET.Model.Context;
using RestAPIWithASPNET.Repository;
using RestAPIWithASPNET.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASPNET.Business
{
    public class PersonBusinessImpl : IPersonBusiness

    {

        private readonly IRepository<Person> repository;

        private readonly PersonAdapter adapter;
        public PersonBusinessImpl(IRepository<Person> personRepository)
        {
            repository = personRepository;
            adapter = new PersonAdapter();
        }

        public List<PersonDTO> ListAll()
        {
            return adapter.Parse(repository.ListAll());
        }

        public PersonDTO FindById(long id)
        {
            return adapter.Parse(repository.FindById(id));
        }

        public PersonDTO Create(PersonDTO person)
        {
            var personEntity = adapter.Parse(person);
            return adapter.Parse(repository.Create(personEntity));
        }

        public PersonDTO Update(PersonDTO person)
        {
            var personEntity = adapter.Parse(person);
            return adapter.Parse(repository.Update(personEntity));
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
