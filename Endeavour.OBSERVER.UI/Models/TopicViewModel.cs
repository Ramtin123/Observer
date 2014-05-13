using Endeavour.DomainClasses.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Endeavour.OBSERVER.Models
{
    public class TopicViewModel
    {
        public int ID { set; get; }
        public string TopicName { set; get; } 
        public TopicViewModel(Topic topic)
        {
            this.ID = topic.ID;   
            this.TopicName = topic.TopicName;
  
        }

    }
}