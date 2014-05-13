using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.BaseObject
{
    public abstract class BaseDataObjectWithStatus:BaseDataObjectWithDate 
    {
        public BaseDataObjectWithStatus()
        {
            this.Status = Status.Active;   
        }
        public Status Status { set; get; }

    }

    public enum Status
    {
        Active=1,
        Inactive=0
    }
}
