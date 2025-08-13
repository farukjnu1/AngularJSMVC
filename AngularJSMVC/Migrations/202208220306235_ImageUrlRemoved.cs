namespace AngularJSMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUrlRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employee", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "ImageUrl", c => c.String());
        }
    }
}
