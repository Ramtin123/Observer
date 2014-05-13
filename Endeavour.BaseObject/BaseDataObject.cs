using Endeavour.BaseObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.BaseObject
{
    public abstract class BaseDataObject: IObjectWithState
    {
        public int ID { get; set; }
        [NotMapped]
        public State State { get; set; }
    }
    
}
