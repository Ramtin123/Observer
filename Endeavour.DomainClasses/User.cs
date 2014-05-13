using Endeavour.DomainClasses.FormBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses
{
    public class User:Person 
    {
        public string Email { set; get; }
        public string Username { set; get; }
        public Reference Reference { set; get; }
        [ForeignKey("Reference")]
        public int ReferenceId { set; get; }
    }
}
