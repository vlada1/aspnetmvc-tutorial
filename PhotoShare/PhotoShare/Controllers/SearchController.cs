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

        public ActionResult ByTag(string tag)
        {
            return Json(new { name = "nirav", age = 21, school = "GT" }, JsonRequestBehavior.AllowGet);
        }

    }
}
