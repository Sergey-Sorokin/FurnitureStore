namespace FurnitureStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FurnitureChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Furnitures", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Furnitures", "Name", c => c.String(maxLength: 100));
        }
    }
}
