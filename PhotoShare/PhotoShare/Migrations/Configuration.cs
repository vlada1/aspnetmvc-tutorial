namespace PhotoShare.Migrations
{
    using PhotoShare.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoShare.Models.PhotoShareDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PhotoShare.Models.PhotoShareDb context)
        {
            context.Albums.AddOrUpdate(

                album => album.Name,
                new Album
                {
                    Name = "Album of Sceneries",
                    Description = "An album containing photos of sceneries",
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            Description = "Check out this shot of sunset!",
                            FilePath = "~/PhotoUploads/sunset.jpg",
                            Rating = 6
                        },

                        new Photo
                        {
                            Description = "These are some beautiful mountains",
                            FilePath = "~/PhotoUploads/mountains.jpg",
                            Rating = 9
                        },

                    }
                },
                new Album
                {
                    Name = "Cookies!",
                    Description = "My favorite cookies in the world",
                    Photos = new List<Photo>
                    {
                        new Photo 
                        {
                            Description = "The classic oreo!",
                            FilePath = "~/PhotoUploads/oreo.jpg",
                            Rating = 8
                        }
                    }
                }

               );

            SeedMemberShip();
        }

        private void SeedMemberShip()
        {
            WebSecurity.InitializeDatabaseConnection("PhotoShareSQLServerDb", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            if (!roles.RoleExists("admin"))
            {
                roles.CreateRole("admin");
            }
            if (!roles.RoleExists("reguser"))
            {
                roles.CreateRole("reguser");
            }
        }
    }
}
