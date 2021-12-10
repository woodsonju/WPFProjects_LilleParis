using AppEchangeDeLivre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEchangeDeLivre.Services
{
    public interface IUserService
    {
        List<User> FindAll();


    }
}
