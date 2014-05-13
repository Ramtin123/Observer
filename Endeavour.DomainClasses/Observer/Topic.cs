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
    public class Topic : BaseDataObjectWithStatus
    {
        
        public int ID { set; get; }
          public string TopicName { get; set; }

          public Form Form { get; set; }
          

    }

}
