using PhotoShare.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoShare.Controllers
{
    //[Authorize]
    [Log]
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult ByTag(string tag)
        {
            throw new Exception("Something terrible has happened");
            return Content("You searched for " + tag);
        }

    }
}
