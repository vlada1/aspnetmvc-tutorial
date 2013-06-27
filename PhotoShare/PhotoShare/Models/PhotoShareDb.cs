using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class PhotoShareDb : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}