using AppQuizz.Model;
using AppQuizz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuizz.Services
{
    //Cette classe doit implementer le comportement metier
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
