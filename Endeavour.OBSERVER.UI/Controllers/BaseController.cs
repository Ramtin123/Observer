using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Endeavour.OBSERVER.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.UserName = "Ramtin Arab"; 
        }
         
    }
}