namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ContactUs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationTitle = c.String(nullable: false, maxLength: 200),
                        LocationAddress = c.String(nullable: false, maxLength: 300),
                        LocationIcon = c.String(nullable: false, maxLength: 50),
                        PhoneTitle = c.String(nullable: false, maxLength: 80),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        PhoneIcon = c.String(nullable: false, maxLength: 50),
                        MailTitle = c.String(nullable: false, maxLength: 80),
                        Email = c.String(nullable: false, maxLength: 100),
                        MailIcon = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Company", "CompanyShortDescription", c => c.String(nullable: false, maxLength: 200, defaultValue: ""));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "CompanyShortDescription");
            DropTable("dbo.ContactUs");
        }
    }
}
