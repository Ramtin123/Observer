using Endeavour.BaseDataLayer;
using Endeavour.DomainClasses.FormBuilder;
using Endeavour.OBSERVERContext;
using Endeavour.RepositoryInterfaces.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.OBSERVERRepository.FormBuilder
{
    public class FormRepository : IFormRepository
    {
        private readonly IObserverContext _context;

        public FormRepository(IUnitOfWork uow)
        {
           _context = uow.Context as IObserverContext;
        }



        public IQueryable<Form> All
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<Form> AllIncluding(params System.Linq.Expressions.Expression<Func<Form, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Form Find(int id)
        {
            return _context.Forms.Where(w => w.ID==id).FirstOrDefault(); 
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
