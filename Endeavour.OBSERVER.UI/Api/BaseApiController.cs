using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Endeavour.OBSERVER.Api
{
    public abstract class BaseApiController : ApiController
    {
        public int _pageSize = 12;
    }
}