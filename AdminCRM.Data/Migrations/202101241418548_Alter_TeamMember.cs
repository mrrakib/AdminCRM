namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_TeamMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeamMember", "Description", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeamMember", "Description");
        }
    }
}
