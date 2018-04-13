using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLite;

namespace SnoreAwayWeb.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {


            using (var db = new BloggingContext())
            {
                db.Database.Migrate();
            }
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            using (var db = new BloggingContext())
            {
                var blog = new Blog { Url = "http://www.yahoo.com" };
                db.Blogs.Add(blog);
                db.SaveChanges();

                return View(db.Blogs.ToList());
            }

            return View();
        }
    }
}
