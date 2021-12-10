using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuizz.Model
{
    public class QuizQuestion
    {
        public int? Id { get; set; }
        public string qstText { get; set; }
        public bool MultipleChoice { get; set; }
        public int NumOrder { get; set; } //Ordre (Numero de la question)

        //ManyToOne
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
        public int? QuizId { get; set; }
    }
}
