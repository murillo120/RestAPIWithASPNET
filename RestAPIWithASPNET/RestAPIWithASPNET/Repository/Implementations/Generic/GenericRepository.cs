using Microsoft.EntityFrameworkCore;
using RestAPIWithASPNET.Model.Base;
using RestAPIWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASPNET.Repository.Implementations.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MySQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = context.Set<T>();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<T> ListAll()
        {
            return dataset.ToList();
        }
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public T Update(T item)
        {
            try
            {
                var foundItem = dataset.SingleOrDefault(param => param.Id == item.Id);
                _context.Entry(foundItem).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            try
            {
                var item = dataset.SingleOrDefault(item => item.Id == id);
                dataset.Remove(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }


    }
}
