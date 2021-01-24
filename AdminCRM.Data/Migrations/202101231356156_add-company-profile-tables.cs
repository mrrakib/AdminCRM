namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcompanyprofiletables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNo = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 150),
                        WelcomeText = c.String(maxLength: 150),
                        CompanyLogoPath = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanySocialProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        ProfileName = c.String(nullable: false, maxLength: 30),
                        ProfileLink = c.String(nullable: false, maxLength: 80),
                        ProfileIcon = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanySocialProfile", "CompanyId", "dbo.Company");
            DropIndex("dbo.CompanySocialProfile", new[] { "CompanyId" });
            DropTable("dbo.CompanySocialProfile");
            DropTable("dbo.Company");
        }
    }
}
