using Endeavour.BaseObject;
using Endeavour.BaseObjects;
using Endeavour.DomainClasses.FormBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses.Observer
{
    public abstract class TopicRecordValue : BaseDataObject
    {
        
        public TopicRecord TopicRecord { set; get; }
        [ForeignKey("TopicRecord")]
        public int TopicRecordId { set; get; }
        public FormField FormField { set; get; }
        [ForeignKey("FormField")]
        public int FormFieldId { set; get; }
    }
}
