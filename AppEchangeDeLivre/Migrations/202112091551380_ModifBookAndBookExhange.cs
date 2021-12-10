namespace AppEchangeDeLivre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifBookAndBookExhange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookExchanges", "OldOwnerId", "dbo.Users");
            DropIndex("dbo.BookExchanges", new[] { "OldOwnerId" });
            AlterColumn("dbo.BookExchanges", "OldOwnerId", c => c.Int());
            CreateIndex("dbo.BookExchanges", "OldOwnerId");
            AddForeignKey("dbo.BookExchanges", "OldOwnerId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookExchanges", "OldOwnerId", "dbo.Users");
            DropIndex("dbo.BookExchanges", new[] { "OldOwnerId" });
            AlterColumn("dbo.BookExchanges", "OldOwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookExchanges", "OldOwnerId");
            AddForeignKey("dbo.BookExchanges", "OldOwnerId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
