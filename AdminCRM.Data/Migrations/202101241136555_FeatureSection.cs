namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeatureSection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeatureMain",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle = c.String(nullable: false, maxLength: 100),
                        MainTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeatureSingle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FeatureSingle");
            DropTable("dbo.FeatureMain");
        }
    }
}
