using AppEchangeDeLivre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEchangeDeLivre.Repositories
{
    public class BookRepository : IBookRepository
    {
        private MyDbContext db;

        public BookRepository(MyDbContext db)
        {
            this.db = db;
        }

        public List<Book> FindAll()
        {
            return db.Books.Include(book => book.Owner).AsNoTracking().ToList();
        }

        public void SaveOrUpdate(BookExchange exc)
        {
            //Opération Save 
            if(exc.Id == null || exc.Id == 0)
            {
                db.Entry(exc.Book).State = EntityState.Modified;
                db.BookExchanges.Add(exc);
            } else  //Opération update
            {
                db.Entry(exc.Book).State = EntityState.Modified;
                db.Entry(exc).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}
