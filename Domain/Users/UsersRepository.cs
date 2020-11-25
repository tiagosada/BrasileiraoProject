using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Infra;

namespace Domain.Users
{
    class UsersRepository
    {
        public void Add(User user)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        public void Remove(User user)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
       public User FindUser(string name)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Users.FirstOrDefault(user => user.Name == name);
            }
        }
        public User SearchForUserId(Guid id)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Users.FirstOrDefault(user => user.Id == id);
            }
        }
    }
    
}