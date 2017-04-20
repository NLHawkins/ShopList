# ShopList

### Objective
To build a Craigslist clone utilizing knowledge of front-end layouts, complex model structuring, image uploads, and pagination.
------
### Features
* ##### User Authentication extended to include preferred location
------

* ##### Dynamically populated category, subcategory, and location lists and dropdown menus


```csharp   
    public class ChooseLocationViewModel
    {
        public int? SelectedLocId { get; set; }
        public IEnumerable<SelectListItem> Locs { get; set; }
    }
```
```csharp
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
```
```csharp
        public ActionResult LocList()
        {
            var model = new ChooseLocationViewModel
            {
                Locs = GetLocs()
            };
            return View(model);
        }
```
![](https://cdn.rawgit.com/NLHawkins/ShopList/3bed9521/ShopList/Uploads/a.png)
-------
* ##### Image Uploads

    ![](https://cdn.rawgit.com/NLHawkins/ShopList/3bed9521/ShopList/Uploads/q.png)
-------
* ##### Items may be filtered by price and date listed, and displayed through list, thumbnail, and gallery views.

    ![](https://cdn.rawgit.com/NLHawkins/ShopList/3bed9521/ShopList/Uploads/zxcv.png)
    
```csharp
    public ActionResult Index(int loc_Id, int subCat_Id, string viewOrder, string view)
    {
        ...
        // view option ("thumb","list", etc) passed to frontend through viewbag
        ViewBag.View = view;
        
        var posts = db.Posts.Where(p => p.SubCat_Id == subCat_Id && p.Loc_Id == loc_Id);
        
        //order logic processed here 
        if (viewOrder == "high")
            {
                ViewBag.Posts = posts.ToList().OrderByDescending(p => p.Price);
            }
        else if...
    }
```
------
*ShopList was built during Week 8 of The Iron Yard's 12-Week immersive web development course*
