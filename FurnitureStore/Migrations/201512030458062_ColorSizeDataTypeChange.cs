namespace FurnitureStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColorSizeDataTypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Furnitures", "Size", c => c.String());
            AlterColumn("dbo.Furnitures", "Color", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Furnitures", "Color", c => c.Int());
            AlterColumn("dbo.Furnitures", "Size", c => c.Int());
        }
    }
}
