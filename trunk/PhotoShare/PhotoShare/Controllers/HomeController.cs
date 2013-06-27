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

        public ActionResult Index(string searchTerm = null)
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
                });

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
