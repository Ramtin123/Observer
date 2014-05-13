using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.BaseObject
{
    public abstract class BaseDataObjectWithDate : BaseDataObject
    {
        public BaseDataObjectWithDate()
        {
            this.DateCreated = DateTime.Now;   
        }
        public System.DateTime DateCreated { get; set; }
    }
}
