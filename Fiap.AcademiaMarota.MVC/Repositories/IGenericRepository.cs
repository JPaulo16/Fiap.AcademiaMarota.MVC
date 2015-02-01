using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.AcademiaMarota.MVC.Repositories
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        T SearchById(int id);
        void Delete(int id);
        ICollection<T> List();
        ICollection<T> SearchFor(Expression<Func<T, bool>> filter);
    }
}
