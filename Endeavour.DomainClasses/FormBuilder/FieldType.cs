using Endeavour.BaseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses.FormBuilder
{
    public class FieldType : BaseDataObject
    {
        public FieldType()
        {
            this.Active = true;
        }
        public FieldTypeCode FieldTypeCode {set;get;}
        public string Title { set; get; }
        
        public bool Active { set; get; }

    }

    public enum FieldTypeCode
    {
        Text = 1,
        Number = 2,
        TelephoneNumber = 3,
        Email = 4,
        Date = 5,
        DisabilityClientsList = 6,
        SupportEmployeesList = 7,
        ServiceList=8

    }
}
