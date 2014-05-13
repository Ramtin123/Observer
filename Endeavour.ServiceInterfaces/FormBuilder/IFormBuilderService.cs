using Endeavour.DomainClasses.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.ServiceInterfaces.FormBuilder
{
    public interface IFormBuilderService
    {
        void AddOrEditFormField(FormField formField);
        IQueryable<FormField> GetFormFields(int formId);
        FormField GetFormField(int formFieldId);
        void DeleteOrDisableFormField(int formFieldId);
        IQueryable<FieldType> GetFieldTypes();

    }
}
