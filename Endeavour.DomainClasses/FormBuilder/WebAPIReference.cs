using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses.FormBuilder
{
    [Table("WebApiReference")]
    public class WebApiReference:Reference
    {
        public string WebApiAddress { set; get; }
    }
}
