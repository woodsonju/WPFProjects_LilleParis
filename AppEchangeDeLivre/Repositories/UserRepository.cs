﻿using AppEchangeDeLivre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEchangeDeLivre.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MyDbContext db;

        public UserRepository(MyDbContext db)
        {
            this.db = db;
        }

        public List<User> FindAll()
        {
            return db.Users.ToList();
        }
    }
}
