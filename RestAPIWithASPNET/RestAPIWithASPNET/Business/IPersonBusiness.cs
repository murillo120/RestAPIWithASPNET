using RestAPIWithASPNET.Data.DTO;
using RestAPIWithASPNET.Model;
using System.Collections.Generic;

namespace RestAPIWithASPNET.Business.Implementations
{
    public interface IPersonBusiness
    {
        PersonDTO Create(PersonDTO person);
        PersonDTO Update(PersonDTO person);
        void Delete(long id);
        PersonDTO FindById(long Id);

        List<PersonDTO> ListAll();
    }
}
