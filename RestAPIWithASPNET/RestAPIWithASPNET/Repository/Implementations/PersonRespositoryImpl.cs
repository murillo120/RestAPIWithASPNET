using RestAPIWithASPNET.Model;
using RestAPIWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASPNET.Repository.Implementations
{
    public class PersonRespositoryImpl : IPersonRepository

    {

        private MySQLContext _context;
        public PersonRespositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> ListAll()
        {
            return _context.Peoples.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Peoples.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.Peoples.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return person;
        }

        public void Delete(long id)
        {

            var result = _context.Peoples.SingleOrDefault(p => p.Id.Equals(id));
            Console.WriteLine(result);
            if(result != null)
            {
                try
                {
                    _context.Peoples.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool Exists(long id)
        {
            return _context.Peoples.Any(p => p.Id.Equals(id));
        }
    }
}
