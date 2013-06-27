using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoShare.Controllers
{
    public class PhotosController : Controller
    {
        //
        // GET: /Photos/

        public ActionResult Index()
        {
            var model = from photo in _photos
                        select photo;
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult LatestPhoto()
        {
            var model = from photo in _photos
                        orderby photo.ID descending
                        select photo;
            //return Content(model.ElementAt(0).Description);
            return PartialView("_Photo", model.First());
        }

        //
        // GET: /Photos/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Photos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Photos/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Photos/Edit/5

        public ActionResult Edit(int id)
        {
            var photo = _photos.Single(p => p.ID == id);
            return View(photo);
        }

        //
        // POST: /Photos/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var photo = _photos.Single(p => p.ID == id);
            if (TryUpdateModel(photo))
            {
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        //
        // GET: /Photos/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Photos/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        static List<Photo> _photos = new List<Photo>
        {
            new Photo
            {
                ID = 1,
                Description = "Check out this shot of sunset!",
                FilePath = "~/PhotoUploads/sunset.jpg",
                Rating = 6
            },

            new Photo
            {
                ID = 2,
                Description = "These are some beautiful mountains",
                FilePath = "~/PhotoUploads/mountains.jpg",
                Rating = 9
            },
        };
    }
}
