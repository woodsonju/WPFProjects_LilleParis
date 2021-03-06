using AppEchangeDeLivre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEchangeDeLivre.Services
{
    public interface IBookService 
    {
        List<Book> FindAll();

        void ValidateExchange(Book book, int newOwnerId);
    }
}
