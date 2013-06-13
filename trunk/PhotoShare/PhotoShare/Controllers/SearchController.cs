using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoShare.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        [Authorize]
        public ActionResult ByTag(string tag)
        {
            return Content("You searched for " + tag);
        }

    }
}
