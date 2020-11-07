using System;
using System.Linq;

namespace Domain.Users
{
    public class UserService
    {
        public Guid Create(string name, Profile profile)
        {
            var user = new User(name, profile);
            if (user.Validate())
            {
                UserRepository.Add(user);
                return user.Id;
            }
            return new Guid();
        }
    }
}