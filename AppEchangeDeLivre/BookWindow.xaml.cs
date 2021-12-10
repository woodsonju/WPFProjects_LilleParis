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
    /// Logique d'interaction pour BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        private MyDbContext db;
        private IBookService bookService;

        public BookWindow()
        {
            InitializeComponent();
            db = new MyDbContext();
            bookService = new BookService(new BookRepository(db));
        }

        private void btnExchange_Click(object sender, RoutedEventArgs e)
        {
            if(DGbooks.SelectedItem != null)
            {
                ExchangeAddWindow w = new ExchangeAddWindow();
                w.Owner = this;
                w.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vous devez choisir un livre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBooks();
        }

        public void LoadBooks()
        {
            DGbooks.ItemsSource = null;
            DGbooks.ItemsSource = bookService.FindAll();
        }
    }
}
