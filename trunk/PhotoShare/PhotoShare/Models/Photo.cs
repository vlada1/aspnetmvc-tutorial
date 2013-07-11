using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoShare.Models
{
    public class Photo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(140)]
        [Display(Name="Blurb")]
        public string Description { get; set; }

        public string FilePath { get; set; }
        
        [Range(1,10)]
        public int Rating { get; set; }
        public int AlbumID { get; set; }

    }
}