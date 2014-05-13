using Endeavour.BaseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses.FormBuilder
{
    public class Reference : BaseDataObject
    {
        public Reference()
        {
            this.Active = true; 
        }
        public string Title {set; get; }
        
        public bool Active { set; get; }
    }
}
