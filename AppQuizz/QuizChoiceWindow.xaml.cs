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

namespace AppQuizz
{
    /// <summary>
    /// Logique d'interaction pour QuizChoiceWindow.xaml
    /// </summary>
    public partial class QuizChoiceWindow : Window
    {
        private QuizService quizService;
        private MyDbContext db;


        public QuizChoiceWindow()
        {
            InitializeComponent();
            db = new MyDbContext();
            quizService = new QuizService(new QuizRepository(db));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboQuizzes.ItemsSource = quizService.FindQuizzes();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if(ComboQuizzes.SelectedItem != null)
            {
                //Récuperer le quiz selectionné
                Quiz selectQuiz = ComboQuizzes.SelectedItem as Quiz;

                //Créer une fenêtre QuizWindow et lui donner le quiz
                QuizWindow qw = new QuizWindow();
                qw.currentQuizTest = new QuizTest { Quiz = selectQuiz, CreationDate = DateTime.Now };
                qw.ShowDialog();
            } else
            {
                MessageBox.Show("Vous devez choisir un Quiz !");
            }
        }
    }
}
