using AppQuizz.Model;
using AppQuizz.Repositories;
using AppQuizz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AppQuizz
{
    /// <summary>
    /// Logique d'interaction pour QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        public QuizTest currentQuizTest {get;set;}
        private int nbQuestions;
        private QuizService quizService;
        private int numQst = 1;
        private QuizQuestion currentQst;
        private DispatcherTimer myTimer;
        private MyDbContext db;

        public QuizWindow()
        {
            InitializeComponent();
            db = new MyDbContext();

            quizService = new QuizService(new QuizRepository(db));

            //On crée un timer
            myTimer = new DispatcherTimer();
            //on fixe l'intervalle 
            myTimer.Interval = TimeSpan.FromSeconds(1);
            myTimer.Tick += timerJob;
        }


        //A chaque Tick cet evenement est declenché
        private void timerJob(object sender, EventArgs e)
        {
            int nb = Convert.ToInt32(TBTimer.Text);
            //On verifie si le nombre est superieur à zero  ==> on met à jour le timer
            if(nb > 0)
            {
                TBTimer.Text = Convert.ToString(nb - 1);
            } else   //SinOn on passe la question suivante
            {
                //Sender : declenche l'evenement
                //EventArgs : Aucun argument à ajouter donc null
                btnNext_Click(sender, null);
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Recuperer le nombre de  question dans la base de données
            nbQuestions = quizService.CountQuestions(currentQuizTest.Quiz.Id.Value);
            //Mets à jour le titre du Quiz
            TBQuizTitle.Text = currentQuizTest.Quiz.Title;

            LoadQuestion();
        }

        /// <summary>
        /// Methode permettant de charger une question
        /// </summary>
        private void LoadQuestion()
        {
            myTimer.Stop();
            TBTimer.Text = "30";
            myTimer.Start();

            //Retourne une question
            currentQst = quizService.FindQuestion(currentQuizTest.Quiz.Id.Value, numQst);

            //Mets à jour le titre de la question 
            TBQuestionTitle.Text = currentQst.qstText;

            //Recupère la liste des reponses  de la question
            List<QuizResponse> responses = quizService.FindResponses(currentQst.Id.Value);

            //On efface le panelResponses
            PanelResponses.Children.Clear();

            //Si c'est une question à choix multiple
            if(currentQst.MultipleChoice)
            {
                //On parcours la liste des reponse
                foreach (QuizResponse r in responses)
                {
                    //Pour chaque reponse
                    CheckBox cb = new CheckBox();
                    cb.Content = r; //On met à jour le content du checkBox avec la reponse
                    PanelResponses.Children.Add(cb);
                }
            } else //sinon c'est à choix unique
            {
                //On parcours la liste des reponse
                foreach (QuizResponse r in responses)
                {
                    //Pour chaque reponse
                    RadioButton radioButton = new RadioButton();
                    radioButton.Content = r; //On met à jour le content du checkBox avec la reponse
                    PanelResponses.Children.Add(radioButton);
                }
            }
        }
    }
}
