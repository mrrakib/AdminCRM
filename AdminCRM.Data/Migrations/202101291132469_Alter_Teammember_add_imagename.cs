namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Teammember_add_imagename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeamMember", "ImageName", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeamMember", "ImageName");
        }
    }
}
