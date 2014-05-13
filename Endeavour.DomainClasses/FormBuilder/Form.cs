using Endeavour.BaseObject;
using Endeavour.DomainClasses.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses.FormBuilder
{
    public class Form:BaseDataObject
    {
        public Form()
        {
            this.FormFields = new List<FormField>(); 
        }
        [Key, ForeignKey("Topic")]
        public int ID { set; get; }
        public string FormName { set; get; }


        
         public Topic Topic { set; get; }

        
        public ICollection<FormField> FormFields { set; get; }
    }
}
