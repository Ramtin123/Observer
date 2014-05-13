using Endeavour.BaseDataLayer;
using Endeavour.DomainClasses.FormBuilder;
using Endeavour.OBSERVERContext;
using Endeavour.RepositoryInterfaces.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Endeavour.OBSERVERRepository.FormBuilder
{
    public class FieldTypeRepository : IFieldTypeRepository
    {
        private readonly IObserverContext _context;

        public FieldTypeRepository(IUnitOfWork uow)
        {
           _context = uow.Context as IObserverContext;
        }

        public IQueryable<FieldType> All
        {
            get { return _context.FieldTypes; }
        }

        public IQueryable<FieldType> AllIncluding(params System.Linq.Expressions.Expression<Func<FieldType, object>>[] includeProperties)
        {
            IQueryable<FieldType> query = _context.FieldTypes;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public FieldType Find(int id)
        {
            return _context.FieldTypes.Where(w => w.ID == id).FirstOrDefault();
        }

        public IUnitOfWork Context
        {
            get { return _context as IUnitOfWork; }
        }

        public void Dispose()
        {
            
        }
    }
}
