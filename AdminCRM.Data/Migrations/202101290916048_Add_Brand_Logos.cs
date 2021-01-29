namespace RapidSale.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Brand_Logos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 200),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Brands");
        }
    }
}
