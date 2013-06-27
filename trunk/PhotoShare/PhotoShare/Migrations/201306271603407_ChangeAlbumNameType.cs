namespace PhotoShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAlbumNameType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "Name", c => c.Int(nullable: false));
        }
    }
}
