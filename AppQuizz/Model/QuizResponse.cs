using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuizz.Model
{
    public class QuizResponse
    {
        public int? Id { get; set; }
        public string RespText { get; set; }
        public string Correct { get; set; }

        //ManyToOne
        [ForeignKey("QuestionId")]
        public QuizQuestion Question { get; set; }
        public int? QuestionId { get; set; }

        public override string ToString()
        {
            return RespText;
        }

    }
}
