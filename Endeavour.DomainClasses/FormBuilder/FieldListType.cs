using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses.FormBuilder
{
    public class FieldListType:FieldType
    {
        public Reference Reference { set; get; }
         [ForeignKey("Reference")]
        public int ReferenceId { set; get; }
    }
}
