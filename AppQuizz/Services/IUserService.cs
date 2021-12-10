using AppQuizz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuizz.Services
{
    public interface IUserService
    {
        List<User> FindAll();
    }
}
