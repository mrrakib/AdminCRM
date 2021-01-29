namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Single_Feature_add_imagename_and_path : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeatureSingle", "ImageName", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeatureSingle", "ImageName");
        }
    }
}
