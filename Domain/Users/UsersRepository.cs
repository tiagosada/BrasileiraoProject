using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Users
{
    static class UserRepository
    {
        public static List<User> _users { get; set; } = new List<User>();
        public static IReadOnlyCollection<User> Users => _users;
        public static void Add(User user)
        {
            _users.Add(user);
        }
        public static User GetUser(Guid id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
    }
    
}