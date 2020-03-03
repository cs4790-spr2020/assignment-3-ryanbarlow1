using System.Collections.Generic;

namespace BlabberApp.Domain
{
    public interface IRepository<T> where T : EntityBase
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}