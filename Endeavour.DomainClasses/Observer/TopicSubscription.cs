using Endeavour.BaseObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses.Observer
{
    public class TopicSubscription : BaseDataObject
    {
        public TopicSubscription()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int ID { set; get; }
        public Topic Topic { set; get; }
        [ForeignKey("Topic")]
        public int TopicId { set; get; }
        public User User { set; get; }
        [ForeignKey("User")]
        public int UserId { set; get; }

        public DateTime CreatedDate { set; get; }
        public DateTime? ExpiryDate { set; get; } 
    }
}
