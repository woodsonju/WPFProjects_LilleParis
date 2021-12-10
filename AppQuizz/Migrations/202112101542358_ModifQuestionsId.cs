namespace AppQuizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifQuestionsId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.QuizResponses", name: "QuestionsId", newName: "QuestionId");
            RenameIndex(table: "dbo.QuizResponses", name: "IX_QuestionsId", newName: "IX_QuestionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.QuizResponses", name: "IX_QuestionId", newName: "IX_QuestionsId");
            RenameColumn(table: "dbo.QuizResponses", name: "QuestionId", newName: "QuestionsId");
        }
    }
}
