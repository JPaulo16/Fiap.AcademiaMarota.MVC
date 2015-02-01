using Fiap.AcademiaMarota.MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fiap.AcademiaMarota.MVC.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AcademiaContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(AcademiaContext _context)
        {
            this._context = _context;
            this._dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public T SearchById(int id)
        {
            return _dbSet.Find(id);
        }
        public ICollection<T> List()
        {
            return _dbSet.ToList();
        }
        public ICollection<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).ToList();
        }
    }
}