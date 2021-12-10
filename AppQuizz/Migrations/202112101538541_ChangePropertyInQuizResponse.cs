namespace AppQuizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertyInQuizResponse : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.QuizResponses", name: "MyProperty_Id", newName: "Question_Id");
            RenameIndex(table: "dbo.QuizResponses", name: "IX_MyProperty_Id", newName: "IX_Question_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.QuizResponses", name: "IX_Question_Id", newName: "IX_MyProperty_Id");
            RenameColumn(table: "dbo.QuizResponses", name: "Question_Id", newName: "MyProperty_Id");
        }
    }
}
