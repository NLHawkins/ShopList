using ShopList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopList.Controllers
{
    public class SubCatController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int loc_Id, int subCat_id, string viewOrder)
        {
            var posts = db.Posts.Where(p => p.SubCat_Id == subCat_id && p.Loc_Id == loc_Id);
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