namespace PhotoShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        FilePath = c.String(),
                        Rating = c.Int(nullable: false),
                        AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Albums", t => t.AlbumID, cascadeDelete: true)
                .Index(t => t.AlbumID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Photos", new[] { "AlbumID" });
            DropForeignKey("dbo.Photos", "AlbumID", "dbo.Albums");
            DropTable("dbo.Photos");
            DropTable("dbo.Albums");
        }
    }
}
