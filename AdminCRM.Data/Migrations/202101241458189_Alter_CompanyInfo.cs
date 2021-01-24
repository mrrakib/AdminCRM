namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_CompanyInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "CopyrightText", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "CopyrightText");
        }
    }
}
