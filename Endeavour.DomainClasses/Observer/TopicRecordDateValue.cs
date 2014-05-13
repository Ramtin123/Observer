using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses.Observer
{
    public class TopicRecordDateValue : TopicRecordValue
    {
        public DateTime Value { set; get; }
       
        
    }
}
