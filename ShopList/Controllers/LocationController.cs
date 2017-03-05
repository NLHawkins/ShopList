using ShopList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopList.Controllers
{
    public class LocationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int loc_id, string viewOrder)
        {
            var posts = db.Posts.Where(p => p.Loc_Id == loc_id);
            if (viewOrder == "high")
            {
                ViewBag.Posts = posts.ToList().OrderByDescending(p => p.Price);
            }
            else if (viewOrder == "low")
            {
                ViewBag.Posts = posts.ToList().OrderBy(p => p.Price);
            }
            else
            {
                ViewBag.Posts = posts.ToList().OrderByDescending(c => c.Created);
            }
            return View();
        }
    }
}