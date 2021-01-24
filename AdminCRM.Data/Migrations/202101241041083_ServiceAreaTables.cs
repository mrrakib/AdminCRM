namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceAreaTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OurServiceMain",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle = c.String(nullable: false, maxLength: 100),
                        MainTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceSingle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Icon = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceSingle");
            DropTable("dbo.OurServiceMain");
        }
    }
}
