using Endeavour.ServiceInterfaces.FormBuilder;
using Endeavour.ServiceLayer.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Endeavour.OBSERVER.Api
{
    public class FieldTypesController : BaseApiController
    {
        private readonly IFormBuilderService _formBuilderService;

        public FieldTypesController(IFormBuilderService formBuilderService)
        {
            this._formBuilderService = formBuilderService;
        }
        public HttpResponseMessage Get()
        {
            try
            {
                var fieldTypes = _formBuilderService.GetFieldTypes().OrderBy(o=>o.FieldTypeCode);
                return Request.CreateResponse(HttpStatusCode.OK, fieldTypes.ToList());
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var fieldType = _formBuilderService.GetFormField(id);
                return Request.CreateResponse(HttpStatusCode.OK, fieldType);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

    }
}
