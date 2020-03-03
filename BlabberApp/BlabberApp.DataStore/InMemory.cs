using BlabberApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlabberApp.DataStore
{
    public class InMemory<T> : IRepository<T> where T : EntityBase
    {
        private Context _context;
        private DbSet<T> _entities;

        public InMemory(Context context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            if (id < 1)
                return null;
            
            return _entities.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
    }
}