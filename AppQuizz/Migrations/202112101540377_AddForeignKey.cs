namespace AppQuizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.QuizResponses", "QuestionsId");
            RenameColumn(table: "dbo.QuizResponses", name: "Question_Id", newName: "QuestionsId");
            RenameIndex(table: "dbo.QuizResponses", name: "IX_Question_Id", newName: "IX_QuestionsId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.QuizResponses", name: "IX_QuestionsId", newName: "IX_Question_Id");
            RenameColumn(table: "dbo.QuizResponses", name: "QuestionsId", newName: "Question_Id");
            AddColumn("dbo.QuizResponses", "QuestionsId", c => c.Int());
        }
    }
}
