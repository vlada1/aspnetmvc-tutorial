using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using System.Data;

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

        public ActionResult Create(int albumId)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase photoFile)
        {
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(photoFile.FileName);
                var path = Path.Combine(Server.MapPath("~/PhotoUploads"), fileName);
                photoFile.SaveAs(path);
                photo.FilePath = "~/PhotoUploads/" + photoFile.FileName;
                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index", "Photos", new { id = photo.AlbumID });
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var model = db.Photos.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Photo photo, HttpPostedFileBase photoFile)
        {
            if (ModelState.IsValid)
            {
                if (photoFile != null)
                {
                    var fileName = Path.GetFileName(photoFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/PhotoUploads"), fileName);
                    photoFile.SaveAs(path);
                    photo.FilePath = "~/PhotoUploads/" + photoFile.FileName;
                }
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Photos", new { id = photo.AlbumID });
            }
            return View(photo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }

}
