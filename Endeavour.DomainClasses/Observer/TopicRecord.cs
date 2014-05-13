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

    public class TopicRecord : BaseDataObject
    {
        public string Title { get; set; }

        public Topic Topic { get; set; }
        [ForeignKey("Topic")]
        public int TopicId { get; set; }

        public ICollection<TopicRecordValue> TopicRecordValues { set; get; }


    }
}
