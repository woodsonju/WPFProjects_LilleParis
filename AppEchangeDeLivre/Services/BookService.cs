using AppEchangeDeLivre.Models;
using AppEchangeDeLivre.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEchangeDeLivre.Services
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public List<Book> FindAll()
        {
            return bookRepository.FindAll();
        }

        /// <summary>
        /// Met à jour le nouveau propriétaire du livre
        /// Au click sur le bouton pour valider l'echange (interface graphique), nous devons créer 
        /// un échange. 
        /// L'échange implique : 
        ///     - L'insertion d'un echange en BDD
        ///     - La modification du proprio du livre
        /// </summary>
        /// <param name="book">Livre echangé</param>
        /// <param name="newOwnerId">Nouveau proprio du livre</param>
        public void ValidateExchange(Book book, int newOwnerId)
        {
            BookExchange exc = new BookExchange { Book = book, BookId = book.Id, OldOwnerId = book.OwnerId };
            exc.CreationDate = DateTime.Now;
            book.OwnerId = newOwnerId; //On met à jour le nouveau propriétaire du livre
            book.Owner = null;

            //TODO la gestion des points des utilisateurs

            bookRepository.SaveOrUpdate(exc);
        }


    }
}
