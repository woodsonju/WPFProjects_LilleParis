using AppEchangeDeLivre.Models;
using AppEchangeDeLivre.Repositories;
using AppEchangeDeLivre.Services;
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

namespace AppEchangeDeLivre
{
    /// <summary>
    /// Logique d'interaction pour ExchangeAddWindow.xaml
    /// </summary>
    public partial class ExchangeAddWindow : Window
    {
        private MyDbContext db;
        private IBookService bookService;
        private IUserService userService;
        private Book currentBook;
        private BookWindow ownerWindow;

        public ExchangeAddWindow()
        {
            InitializeComponent();
            db = new MyDbContext();
            bookService = new BookService(new BookRepository(db));
            userService = new UserService(new UserRepository(db));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ownerWindow = (BookWindow)this.Owner;  //On récupère la fenêtre appelante (BookWindow)
            currentBook = ownerWindow.DGbooks.SelectedItem as Book; //On recupère le livre selectionné
            
            //On met à jour le champs TBBook avec le titre du livre
            TBBook.Text = currentBook.Title;
            //On met à jour le champs du proprietaire avec le nom du proprietaire du livre
            TBActualOwner.Text = currentBook.Owner.Name;

            ComboNewOwner.ItemsSource = null;
            //On recupère la liste des users qui n'ont pas ce livre
            ComboNewOwner.ItemsSource = userService.FindAll().FindAll(ux => ux.Id.Value != currentBook.OwnerId.Value);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //On recupère le nouveau propriétaire du livre selectionné dans le  comboBox
            int newOwnerId = (ComboNewOwner.SelectedItem as User).Id.Value;

            //Appelle la méthode ValidateExchange de BookService afin de valider l'echange
            //Ceci permettra de mettre à jour le nouveau propriétaire du livre
            bookService.ValidateExchange(currentBook, newOwnerId);

            //On appelle la méthode LoadBooks pour mettre à jour la liste des livres sur son interface graphique
            ownerWindow.LoadBooks();

            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
