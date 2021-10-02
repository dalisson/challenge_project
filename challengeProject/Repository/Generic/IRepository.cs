using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Model.Base;

namespace challengeProject.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);

        T FindByID(int id);

        List<T> FindAll();

        T Update(T item);

        void Delete(int id);

        bool recordOnDb(int Id);
    }
}
