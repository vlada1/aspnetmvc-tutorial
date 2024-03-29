﻿using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PhotoShare.Controllers
{
   
    public class HomeController : Controller
    {

        PhotoShareDb pdb = new PhotoShareDb();

        public ActionResult Autocomplete(string term)
        {
            var model = pdb.Albums.
                Where(album => album.Name.StartsWith(term)).
                Take(10).Select(a => new
                {
                    label = a.Name
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            // Comprehension Query Syntax
            //var model = from album in pdb.Albums
            //            orderby album.Photos.Count() descending
            //            select new AlbumsListViewModel
            //            {
            //                Name = album.Name,
            //                Description = album.Description,
            //                PhotosCount = album.Photos.Count()
            //            };

            // Extension Method Syntax
            var model = pdb.Albums.
                OrderByDescending(album => album.Photos.Count()).
                Where(album => searchTerm == null || album.Name.StartsWith(searchTerm)).
                Take(10).Select(album => new AlbumsListViewModel
                {
                    Name = album.Name,
                    Description = album.Description,
                    PhotosCount = album.Photos.Count()
                }).ToPagedList(page, 1);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Photos", model);
            }

            return View(model);
        }

        //[Authorize]
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
