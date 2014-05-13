using Endeavour.DomainClasses.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.RepositoryInterfaces.FormBuilder
{
    public interface IFormFieldRepository:IRepository
    {
        IQueryable<FormField> GetFormFields(int formId);
        FormField Find(int id);
        void InsertOrUpdate(FormField entity);
        void Delete(int id);
    }
}
