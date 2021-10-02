using challengeProject.Model.Base;
using challengeProject.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challengeProject.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> dataset;
        public GenericRepository(MySQLContext context)

        {
            _context = context;
            dataset = _context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public void Delete(int id)
        {
            var tempItem = dataset.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                dataset.Remove(tempItem);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindByID(int id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

     

        public T Update(T item)
        {
            if (recordOnDb(item.Id)) return null;
            var tempRecord = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            try
            {
                _context.Entry(tempRecord).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public bool recordOnDb(int Id)
        {
            return dataset.Any(p => p.Id.Equals(Id));
        }

    }
}
