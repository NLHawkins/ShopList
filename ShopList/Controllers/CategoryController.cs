using ShopList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopList.Controllers
{

    public class CategoryController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        /*
        public ActionResult Index(int page, int maxThumbs, int catId)
        {
            var allPosts = db.Posts.Where(c => c.Cat_Id == catId).OrderByDescending(c => c.Created);
            int showPage = page;
            int showThumbs = maxThumbs;
            int skipThumbs = page-- * maxThumbs;
            List<Post> posts = allPosts.Skip(skipThumbs).Take(showThumbs).ToList();
            ViewBag.posts = posts;
            return (ViewBag.posts);
        }
        */

        public ActionResult Index(int loc_Id, int cat_Id, string viewOrder)
        {
            var posts = db.Posts.Where(p => p.Cat_Id == cat_Id && p.Loc_Id == loc_Id);
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