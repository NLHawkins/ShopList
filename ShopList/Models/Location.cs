using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopList.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Locale { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }

    public class ChooseLocationViewModel
    {
        public int? SelectedLocId { get; set; }
        public IEnumerable<SelectListItem> Locs { get; set; }
    }
        
}