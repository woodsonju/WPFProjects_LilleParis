namespace AppQuizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        qstText = c.String(),
                        NumOrder = c.Int(nullable: false),
                        QuizId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.QuizId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizCategories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.QuizResponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RespText = c.String(),
                        Correct = c.String(),
                        QuestionsId = c.Int(),
                        MyProperty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizQuestions", t => t.MyProperty_Id)
                .Index(t => t.MyProperty_Id);
            
            CreateTable(
                "dbo.QuizTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        QuizId = c.Int(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.QuizId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.QuizId);
            
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
            DropForeignKey("dbo.QuizTests", "UserId", "dbo.Users");
            DropForeignKey("dbo.QuizTests", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.QuizResponses", "MyProperty_Id", "dbo.QuizQuestions");
            DropForeignKey("dbo.QuizQuestions", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.Quizs", "CategoryId", "dbo.QuizCategories");
            DropIndex("dbo.QuizTests", new[] { "QuizId" });
            DropIndex("dbo.QuizTests", new[] { "UserId" });
            DropIndex("dbo.QuizResponses", new[] { "MyProperty_Id" });
            DropIndex("dbo.Quizs", new[] { "CategoryId" });
            DropIndex("dbo.QuizQuestions", new[] { "QuizId" });
            DropTable("dbo.Users");
            DropTable("dbo.QuizTests");
            DropTable("dbo.QuizResponses");
            DropTable("dbo.Quizs");
            DropTable("dbo.QuizQuestions");
            DropTable("dbo.QuizCategories");
        }
    }
}
