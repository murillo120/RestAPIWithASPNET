using RestAPIWithASPNET.Data.Adapter.Contract;
using RestAPIWithASPNET.Data.DTO;
using RestAPIWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASPNET.Data.Adapter.Imprementations
{
    public class PersonAdapter : IParser<Person, PersonDTO>, IParser<PersonDTO, Person>
    {
        public Person Parse(PersonDTO origin)
        {
            if (origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }
        public PersonDTO Parse(Person origin)
        {
            if (origin == null) return null;
            return new PersonDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<PersonDTO> Parse(List<Person> origin)
        {
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Person> Parse(List<PersonDTO> origin)
        {
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
