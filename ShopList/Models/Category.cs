using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopList.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CatTag { get; set; }

        public virtual ICollection<SubCategory> SubCats { get; set; }
    }

    
}