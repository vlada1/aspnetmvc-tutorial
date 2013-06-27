using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {

        PhotoShareDb pdb = new PhotoShareDb();

        public ActionResult Index()
        {
            var model = pdb.Albums.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Nirav";
            model.Location = "Atlanta,GA";
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (pdb != null)
                pdb.Dispose();
            base.Dispose(disposing);
        }
    }
}
