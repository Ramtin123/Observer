using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Endeavour.OBSERVER.Models
{
    public class ApiListContainerModel<T>
    {
        public ApiListContainerModel()
        {
            List = new List<T>();
        }
        public int Page { set; get; }
        public int PageCount{set;get;}

        public IList<T> List { set; get; }

    }
}