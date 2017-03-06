using Microsoft.AspNet.Identity;
using ShopList.Extensions;
using ShopList.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopList.Controllers
{
    public class PostController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Details(int id)
        {
            var post = db.Posts.Where(p => p.Id == id).FirstOrDefault();
            var img = db.Images.Where(i => i.Id == post.Img_Id).FirstOrDefault();
            ViewBag.UserId = User.Identity.GetUserId();
            ViewBag.FilePath = img.FilePath;
            return View(post);
        }

        public ActionResult Index(int loc_id)
        {
            var posts = db.Posts.Where(p => p.Loc_Id == loc_id);
            ViewBag.Posts = posts.ToList().OrderByDescending(c => c.Created);
            return View();
        }

        public ActionResult UserIndex(string id)
        {
            var posts = db.Posts.Where(p => p.Owner_Id == id);
            ViewBag.Posts = posts.ToList().OrderByDescending(c => c.Created);
            return View();
        }

        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Login");
            }
            var model = new CreatePostViewModel
            {
                SubCats = GetSubCats(),
                Locs = GetLocs()
            };
            
            return View(model);

             
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                var uploadedFile = Request.Files[0];
                string filename = $"{DateTime.Now.Ticks}{uploadedFile.FileName}";
                var serverPath = Server.MapPath(@"~\Uploads");
                var fullPath = Path.Combine(serverPath, filename);
                uploadedFile.SaveAs(fullPath);

                var image = new ImageUpload
                {
                    File = filename,
                    PostId = post.Id
                };
                db.Images.Add(image);

                var subCat_Id = int.Parse(Request.Form["SelectedSubCatId"]);
                post.SubCat_Id = subCat_Id;
                var subCat = db.SubCats.Find(subCat_Id);
                post.Img_Id = image.Id;
                post.Loc_Id = int.Parse(Request.Form["SelectedLocId"]);
                post.Cat_Id = subCat.CategoryId;
                post.Description = Request.Form["PostDescription"];
                post.Name = Request.Form["PostName"];
                post.Price = double.Parse(Request.Form["Price"]);
                post.Created = DateTime.Now;
                post.Owner_Id = User.Identity.GetUserId();
                post.Updated = DateTime.Now;
                db.Posts.Add(post);

                db.SaveChanges();
                return RedirectToAction("Details", new { id = post.Id});
            }


            return View(post);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var post = db.Posts.Where(p => p.Id == id).First();
            if (post.Owner_Id == User.Identity.GetUserId())
            {
                return View();
            }
            return RedirectToAction("Index");
        }   
        

        [HttpPost]
        [Authorize]
        public ActionResult DeletePost(int id)
        {


            var post = db.Posts.Where(p => p.Id == id).First();
            if (post.Owner_Id == User.Identity.GetUserId())
            {
                db.Posts.Remove(post);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
            
        }

        private IEnumerable<SelectListItem> GetSubCats()

        {

            var subCats = db.SubCats
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Cat.CatTag + " - " + x.Title
                                });

            return new SelectList(subCats, "Value", "Text");
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
