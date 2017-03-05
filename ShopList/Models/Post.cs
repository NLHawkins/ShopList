using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopList.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Owner_Id { get; set; }
        public int Cat_Id { get; set; }
        public int SubCat_Id { get; set; }
        public int Loc_Id { get; set; }
        public int Img_Id { get; set; }

        [ForeignKey("Img_Id")]
        public virtual ImageUpload Image { get; set; }
        [ForeignKey("Loc_Id")]
        public virtual Location Location { get; set; }
        [ForeignKey("SubCat_Id")]
        public virtual SubCategory SubCategory { get; set; }
    }
}