using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class Album
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}