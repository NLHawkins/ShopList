using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopList.Models
{
    public class HomeListViewModel
    {
        public ICollection<Category> Cats { get; set; }
        public ICollection<SubCategory> SubCats { get; set; }
    }


}