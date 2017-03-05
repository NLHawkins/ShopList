using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopList.Models
{
    public class ImageUploadViewModel
    {
        [Required]
        public HttpPostedFile File { get; set; }
    }

    public class ImageUpload
    {
        public int Id { get; set; }
        public string File { get; set; }
        public int PostId { get; set; }

        public virtual string FilePath
        {
            get
            {
                return $"/Uploads/{File}";
            }
        }
    }
}