using AppEchangeDeLivre.Models;
using AppEchangeDeLivre.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEchangeDeLivre.Services
{
    //Cette classe doit implementer le comportement métier
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public List<User> FindAll()
        {
            return userRepository.FindAll();
        }

    }
}
