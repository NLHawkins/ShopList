using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopList.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Cat { get; set; }
    }


}