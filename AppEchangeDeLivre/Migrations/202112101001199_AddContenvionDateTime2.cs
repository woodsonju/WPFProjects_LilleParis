namespace AppEchangeDeLivre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContenvionDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookExchanges", "CreationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Books", "EditionDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "EditionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookExchanges", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
