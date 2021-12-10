namespace AppQuizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdMultipleChoiceInQuizQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuizQuestions", "MultipleChoice", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuizQuestions", "MultipleChoice");
        }
    }
}
