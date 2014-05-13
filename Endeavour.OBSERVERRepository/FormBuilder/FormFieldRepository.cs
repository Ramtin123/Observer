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
    public class FormFieldRepository : IFormFieldRepository
    {
        private readonly IObserverContext _context;

        public FormFieldRepository(IUnitOfWork uow)
        {
           _context = uow.Context as IObserverContext;
        }

        public IQueryable<FormField> GetFormFields(int formId)
        {
            return _context.FormFields.Include(q => q.FieldType).Where(w => w.FormId == formId);
        }

        public FormField Find(int id)
        {
            return _context.FormFields.Include(q => q.FieldType).Where(w => w.ID == id).FirstOrDefault();
        }

        public void InsertOrUpdate(FormField entity)
        {
            if (entity.ID == default(int)) // New entity
            {
                _context.SetAdd(entity);
            }
            else        // Existing entity
            {
                _context.SetModified(entity);
            }
            
        }

        public void Delete(int id)
        {
            var entity = _context.FormFields.Find(id);
            _context.FormFields.Remove(entity);
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
