using Endeavour.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses
{
    public class Person
    {
       
        public Guid PersonGuidId { set; get; }
        public int PersonId { set; get; }

        public string FName { set; get; }
        public string MName { set; get; }
        public string SName { set; get; }

        public string FullName
        {
            get
            {
                return ((string.IsNullOrEmpty(FName)==false?FName.Trim()+" ":"") +(string.IsNullOrEmpty(MName)==false?MName.Trim()+" ":"")+(string.IsNullOrEmpty(SName)==false?SName.Trim():"")).Trim();
            }
        }
       
       

       
       
    }
   
}
