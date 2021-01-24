namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutExperience : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExperienceSection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle = c.String(nullable: false, maxLength: 100),
                        MainTitle = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ExperiencePercentage = c.Int(nullable: false),
                        ProjectPercentage = c.Int(nullable: false),
                        SupportPercentage = c.Int(nullable: false),
                        CleanPercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExperienceSection");
        }
    }
}
