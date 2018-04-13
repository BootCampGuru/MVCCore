using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnoreAwayCore.Models;
using SQLitePCL;

namespace SnoreAwayCore.Controllers
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
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";

            using (var db = new BloggingContext())
            {
                var blog = new Blog { Url = "http://www.yahoo.com" };
                db.Blogs.Add(blog);
                db.SaveChanges();

                return View(db.Blogs.ToList());
            }

            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
