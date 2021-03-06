using AppEchangeDeLivre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEchangeDeLivre.Repositories
{
    public interface IBookRepository 
    {
        List<Book> FindAll();
        void SaveOrUpdate(BookExchange exc);
    }
}
