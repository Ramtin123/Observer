using Endeavour.BaseDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.RepositoryInterfaces
{
    public interface IEntityRepository<T> : IRepository
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void InsertOrUpdate(T entity);
        void Delete(int id);
    }

    public interface IReadOnlyEntityRepository<T> : IRepository
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        
    }



    public interface IRepository:IDisposable
    {
        IUnitOfWork Context { get; }
    }
}
