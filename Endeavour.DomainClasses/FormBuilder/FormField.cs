using Endeavour.BaseObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses.FormBuilder
{
    public class FormField : BaseDataObject
    {
        public FormField()
        {
            this.Active = true;
        }
        public string FieldName { set; get; }
        public FieldType FieldType { set; get; }
        [ForeignKey("FieldType")]
        public int FieldTypeId { set; get; }
               
        public Form Form { set; get; }

        [ForeignKey("Form")]
        public int FormId { set; get; }

        public bool IsEditable { set; get; }
        public bool AutomaticUpdate { set; get; }

        public bool Active { set; get; }

    }

    
}
