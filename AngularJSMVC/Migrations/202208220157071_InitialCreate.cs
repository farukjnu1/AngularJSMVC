namespace AngularJSMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GenderId = c.Int(nullable: false),
                        JoiningDate = c.DateTime(nullable: false, storeType: "date"),
                        Salary = c.Decimal(nullable: false, storeType: "money"),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gender", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "GenderId", "dbo.Gender");
            DropIndex("dbo.Employee", new[] { "GenderId" });
            DropTable("dbo.Gender");
            DropTable("dbo.Employee");
        }
    }
}
