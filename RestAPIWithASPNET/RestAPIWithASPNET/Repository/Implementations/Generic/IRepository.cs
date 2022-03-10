using RestAPIWithASPNET.Model;
using RestAPIWithASPNET.Model.Base;
using System.Collections.Generic;

namespace RestAPIWithASPNET.Repository.Implementations
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        void Delete(long id); 
        T FindById(long id);
        List<T> ListAll();

        bool Exists(long id);
    }
}
