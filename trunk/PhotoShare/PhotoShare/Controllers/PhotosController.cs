using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PhotoShare.Controllers
{
    public class PhotosController : Controller
    {
        //
        // GET: /Photos/

        PhotoShareDb db = new PhotoShareDb();

        public ActionResult Index(int id)
        {
            var model = db.Albums.Find(id);
            return View(model);
        }

    }

}
