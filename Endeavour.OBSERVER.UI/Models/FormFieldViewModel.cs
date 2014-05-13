using Endeavour.DomainClasses.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Endeavour.OBSERVER.Models
{
    public class FormFieldViewModel
    {
        public int ID { set; get; }
        public string FieldName { set; get; }
        public int FieldTypeId { set; get; }
        public int FieldTypeCode { set; get; }
        public string FieldTypeName { set; get; }
        public bool IsList { set; get; }
        public bool IsEditable { set; get; }

        public FormFieldViewModel(FormField formField)
        {
            this.ID = formField.ID;
            this.FieldName = formField.FieldName;
            this.FieldTypeId = formField.FieldTypeId;
            this.IsEditable = formField.IsEditable;
            if (formField.FieldType != null)
            {
                this.FieldTypeCode = (int)formField.FieldType.FieldTypeCode;
                this.FieldTypeName = formField.FieldType.Title;
                this.IsList =(formField.GetType()==typeof(FieldListType)?true:false);
            }
           
           

        }
    }
}

    