using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Endeavour.OBSERVER.Models
{
    public class SubscriptionViewModel
    {
        public string FName { set; get; }
        public string SName { set; get; }
        public string Name
        {
            get
            {
                return this.FName + " " + this.SName;  
            }
        }
        public string Email { set; get; }
        public string UserName { set; get; }
        public int UserId { set; get; }
        public int TopicId { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime ExpiryDate { set; get; }
    }
}