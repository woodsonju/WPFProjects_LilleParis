using AppQuizz.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuizz.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        /*
         * 2 façon d'utiliser LINQ : Soit avec la syntaxe - soit via des appels successifs de méthodes
         * 1- Syntaxe Linq : Convient aux dev sql
         * 2-Chainage de méthode convient au dev
         */

        private MyDbContext db;

        public QuizRepository(MyDbContext db)
        {
            this.db = db;
        }

        public int CountQuestions(int quizId)
        {
            return db.QuizQuestions.AsNoTracking().Where(qst => qst.QuizId == quizId).Count();
            //return (from qst in db.QuizQuestions.AsNoTracking() where qst.QuizId == quizId select qst).Count();
        }

        public QuizQuestion FindQuestion(int quizId, int numOrder)
        {
            return db.QuizQuestions.AsNoTracking().SingleOrDefault(qst => qst.QuizId == quizId && qst.NumOrder == numOrder);
        }

        public Quiz FindQuizById(int quizId)
        {
            return db.Quizzes.Find(quizId);
        }

        public List<Quiz> FindQuizzes()
        {
            //Avec le Include on peut faire la jointure et recuperer les valeurs de db.Quizzes.Include(...)
            return db.Quizzes.Include(qz => qz.Category).AsNoTracking().ToList();
        }

        public QuizResponse FindResponseById(int responseId)
        {
            return db.QuizResponses.Find(responseId);
        }

        public List<QuizResponse> FindResponses(int questionId)
        {
            return db.QuizResponses.AsNoTracking().Where(r => r.QuestionId == questionId).ToList();
        }
    }
}
