namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_slider_Alter_Experience_add_img : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleOne = c.String(nullable: false, maxLength: 100),
                        TitleTwo = c.String(nullable: false, maxLength: 80),
                        TaglineOne = c.String(nullable: false, maxLength: 150),
                        TaglineTwo = c.String(nullable: false, maxLength: 120),
                        ButtonText = c.String(nullable: false, maxLength: 30),
                        ButtonLink = c.String(maxLength: 200),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ExperienceSection", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExperienceSection", "ImagePath");
            DropTable("dbo.Slider");
        }
    }
}
