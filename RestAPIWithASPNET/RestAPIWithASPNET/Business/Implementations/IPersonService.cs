using RestAPIWithASPNET.Model;
using System.Collections.Generic;

namespace RestAPIWithASPNET.Business.Implementations
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
        Person FindById(long Id);

        List<Person> ListAll();
    }
}
