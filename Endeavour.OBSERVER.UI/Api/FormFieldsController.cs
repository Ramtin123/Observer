using Endeavour.DomainClasses.FormBuilder;
using Endeavour.OBSERVER.Models;
using Endeavour.ServiceInterfaces.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Endeavour.OBSERVER.Api
{
    public class FormFieldsController : BaseApiController
    {
        private readonly IFormBuilderService _formBuilderService;

        public FormFieldsController(IFormBuilderService formBuilderService)
        {
            this._formBuilderService = formBuilderService;
        }
        public HttpResponseMessage Get(int formid)
        {
            try
            {
                IList<FormFieldViewModel> formFieldViewModels = new List<FormFieldViewModel>();
                var formFields = _formBuilderService.GetFormFields(formid).OrderBy(o=>o.ID);
                foreach (FormField formField in formFields.ToList())
                {
                    formFieldViewModels.Add(new FormFieldViewModel(formField));
                }
                return Request.CreateResponse(HttpStatusCode.OK, formFieldViewModels);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage Get(int formid, int id)
        {
            try
            {
                var formField = _formBuilderService.GetFormField(id);
                return Request.CreateResponse(HttpStatusCode.OK, formField);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

         public HttpResponseMessage Post([FromBody]FormField formField)
        {
            try
            {
                _formBuilderService.AddOrEditFormField(formField); 
                return Request.CreateResponse(HttpStatusCode.Created,
                                  new FormFieldViewModel(formField));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            

           
        }

        public HttpResponseMessage Put(int id, [FromBody]FormField formField)
        {
            try
            {

                var OldformField = _formBuilderService.GetFormField(id);
                //change editable fields
                OldformField.FieldName = formField.FieldName;
                OldformField.IsEditable = formField.IsEditable;
                _formBuilderService.AddOrEditFormField(OldformField); 
                return Request.CreateResponse(HttpStatusCode.Accepted,
                                 new FormFieldViewModel(OldformField));

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _formBuilderService.DeleteOrDisableFormField(id);
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

    }



   
}
