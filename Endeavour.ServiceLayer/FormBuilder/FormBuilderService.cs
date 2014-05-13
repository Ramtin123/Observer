using Endeavour.BaseDataLayer;
using Endeavour.DomainClasses.FormBuilder;
using Endeavour.RepositoryInterfaces.FormBuilder;
using Endeavour.ServiceInterfaces.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.ServiceLayer.FormBuilder
{
    public class FormBuilderService : IFormBuilderService
    {
        private readonly IFormFieldRepository _formFieldRepository;
        private readonly IFieldTypeRepository _fieldTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FormBuilderService(IFormFieldRepository formFieldRepository, IFieldTypeRepository fieldTypeRepository, IUnitOfWork unitOfWork)
        {
            _formFieldRepository = formFieldRepository;
            _fieldTypeRepository = fieldTypeRepository;
            _unitOfWork = unitOfWork;
        }

       

        public void AddOrEditFormField(FormField formField)
        {
            if (formField.ID == default(int))
            {
                formField.Active=true; 
            }
            _formFieldRepository.InsertOrUpdate(formField);
            _unitOfWork.Save();
        }

        public IQueryable<FormField> GetFormFields(int formId)
        {
            return _formFieldRepository.GetFormFields(formId).Where(w => w.Active == true);
        }

        public FormField GetFormField(int formFieldId)
        {
            return _formFieldRepository.Find(formFieldId);
        }

        public void DeleteOrDisableFormField(int formFieldId)
        {
           try
           {
               _formFieldRepository.Delete(formFieldId);
               _unitOfWork.Save();
           }
            catch
           {
               FormField formField = _formFieldRepository.Find(formFieldId);
               formField.Active = false;
               _formFieldRepository.InsertOrUpdate(formField);
               _unitOfWork.Save();
           }


        }

        public IQueryable<FieldType> GetFieldTypes()
        {
            return _fieldTypeRepository.All.Where(w=>w.Active==true);
        }
    }
}
