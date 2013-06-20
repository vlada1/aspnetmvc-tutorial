using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
    }
}