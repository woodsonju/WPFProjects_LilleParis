using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuizz.Model
{
    public class Quiz
    {
        public int? Id { get; set; }
        public string Title { get; set; }

        //OneToMany
        /* public List<QuizQuestion> Questions { get; set; }*/

        //Many Quiz to One Category
        [ForeignKey("CategoryId")]
        public QuizCategory Category { get; set; }
        public int? CategoryId { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
