using AppQuizz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuizz.Repositories
{
    public interface IUserRepository
    {
        List<User> FindAll();
    }
}
