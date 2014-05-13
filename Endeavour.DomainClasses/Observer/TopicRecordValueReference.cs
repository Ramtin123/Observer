using Endeavour.BaseObject;
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
    public class TopicRecordValueReference : BaseDataObject
    {
        public TopicRecordValueReference()
        {
            this.LastUpdate = DateTime.Now;
        }
        [Key,ForeignKey("TopicRecordValue")]
        public int ID { set; get; }
        public int? UID { set; get; }
        public Guid? GUID { set; get; }
        public WebApiReference Reference { set; get; }
        [ForeignKey("Reference")]
        public int ReferenceId { set; get; }
        public TopicRecordValue TopicRecordValue { set; get; }
        public DateTime LastUpdate { set; get; }
    }
}
