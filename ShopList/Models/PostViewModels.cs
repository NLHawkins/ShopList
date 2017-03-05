using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopList.Models
{
    public class CreatePostViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string PostName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string PostDescription { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Cat { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "SubCategory")]
        public int? SelectedSubCatId { get; set; }
        public IEnumerable<SelectListItem> SubCats { get; set; }
        [Required]
        [Display(Name = "Location")]
        public int? SelectedLocId { get; set; }
        public IEnumerable<SelectListItem> Locs { get; set; }
        [Display(Name = "Image")]
        public string File { get; set; }
    }

    public class PostDetailsViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string PostName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string PostDescription { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Cat { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "SubCategory")]
        public int? SelectedSubCatId { get; set; }
        public IEnumerable<SelectListItem> SubCats { get; set; }
        [Required]
        [Display(Name = "Location")]
        public int? SelectedLocId { get; set; }
        public IEnumerable<SelectListItem> Locs { get; set; }
        [Display(Name = "Image")]
        public string File { get; set; }
    }


}