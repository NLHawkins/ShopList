using Microsoft.AspNet.Identity;
using ShopList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopList.Controllers
{
    
    public class HomeController : Controller
    {
        public static ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult HomeList(int loc_Id)
        {
            ViewBag.loc_Id = loc_Id;
            var model = new HomeListViewModel
            {
                Cats = GetCats(),
                SubCats = GetSubCats()  
            };
            var loc = db.Locs.Where(x => x.Id == loc_Id).FirstOrDefault();
            ViewBag.loc_Name = loc.Locale;
            return View(model);

        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                var model = new ChooseLocationViewModel
                {
                    Locs = GetLocs()
                };

                return View(model);
            }
            var userInstance = db.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (userInstance == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var u_loc_Id = userInstance.PrefLocId;
            return RedirectToAction("HomeList", "Home", new { loc_Id = u_loc_Id });
            
            
        }

        public ActionResult LocList()
        {
            var model = new ChooseLocationViewModel
            {
                Locs = GetLocs()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ChooseLocation()
        {
            var loc_Id = int.Parse(Request.Form["SelectedLocId"]);
            return RedirectToAction("HomeList", "Home", new { loc_id = loc_Id });
        }

        private ICollection<Category> GetCats()
        {
            var cats = db.Cats.ToList();
            return cats;
        }

        private ICollection<SubCategory> GetSubCats()
        {
            var subCats = db.SubCats.ToList();
            return subCats;
        }

        private IEnumerable<SelectListItem> GetLocs()
        {

            var locs = db.Locs
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Locale
                                });

            return new SelectList(locs, "Value", "Text");
        }
    }
}