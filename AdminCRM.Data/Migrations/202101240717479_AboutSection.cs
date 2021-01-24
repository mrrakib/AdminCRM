namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutSection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutSection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle = c.String(nullable: false, maxLength: 100),
                        MainTitle = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ListOneTitle = c.String(nullable: false, maxLength: 100),
                        ListOneDescription = c.String(nullable: false),
                        ListOneIcon = c.String(nullable: false, maxLength: 50),
                        ListSecondTitle = c.String(nullable: false, maxLength: 100),
                        ListSecondDescription = c.String(nullable: false),
                        ListSecondIcon = c.String(nullable: false, maxLength: 50),
                        ButtonText = c.String(nullable: false, maxLength: 40),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutSection");
        }
    }
}
