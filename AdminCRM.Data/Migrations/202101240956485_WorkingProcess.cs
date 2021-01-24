namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkingProcess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkProcessSection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle = c.String(nullable: false, maxLength: 100),
                        MainTitle = c.String(nullable: false),
                        Description = c.String(),
                        ProcessOneIcon = c.String(nullable: false, maxLength: 50),
                        ProcessOneTitle = c.String(nullable: false, maxLength: 80),
                        ProcessOneDesc = c.String(nullable: false),
                        ProcessTwoIcon = c.String(nullable: false, maxLength: 50),
                        ProcessTwoTitle = c.String(nullable: false, maxLength: 80),
                        ProcessTwoDesc = c.String(nullable: false),
                        ProcessThreeIcon = c.String(),
                        ProcessThreeTitle = c.String(nullable: false, maxLength: 80),
                        ProcessThreeDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkProcessSection");
        }
    }
}
