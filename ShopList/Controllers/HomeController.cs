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
            var model = new HomeListViewModel
            {
                Cats = GetCats(),
                SubCats = GetSubCats()  
            };
            
            return View(model);

        }

        public ActionResult Index()
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

        private ICollection<SubCategory> GetSubCats(int cat_Id)
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