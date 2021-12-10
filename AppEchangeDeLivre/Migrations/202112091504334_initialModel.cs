namespace AppEchangeDeLivre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookExchanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        BookId = c.Int(nullable: false),
                        OldOwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.OldOwnerId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.OldOwnerId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isbn = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Author = c.String(),
                        Price = c.Double(nullable: false),
                        EditionDate = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        OwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        TotalPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookExchanges", "OldOwnerId", "dbo.Users");
            DropForeignKey("dbo.BookExchanges", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "OwnerId", "dbo.Users");
            DropIndex("dbo.Books", new[] { "OwnerId" });
            DropIndex("dbo.BookExchanges", new[] { "OldOwnerId" });
            DropIndex("dbo.BookExchanges", new[] { "BookId" });
            DropTable("dbo.Users");
            DropTable("dbo.Books");
            DropTable("dbo.BookExchanges");
        }
    }
}
