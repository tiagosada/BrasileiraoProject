using System;
using System.Linq;

namespace Domain.Users
{
    public class UserService
    {
        public Guid Create(string name, Profile profile)
        {
            var user = new User(name, profile);
            user.Validate();
            UserRepository.Add(user);
            return user.Id;
        }
    }
}