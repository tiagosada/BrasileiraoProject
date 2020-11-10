using System;
using System.Linq;

namespace Domain.Users
{
    public class UserService
    {
        public CreatedUserDTO Create(string name, Profile profile)
        {
            var user = new User(name, profile);
            var userValidation = user.Validate();

            if (userValidation.isValid)
            {
                UserRepository.Add(user);
                return new CreatedUserDTO(user.Id);
            }
            return new CreatedUserDTO(userValidation.errors);
        }
        public User GetUser(Guid id)
        {
            return UserRepository.GetUser(id);
        }
        public bool ContainsUser(string id)
        {
            var userId = Guid.Parse(id);
            return UserRepository.Users.Any(x => x.Id == userId);
        }
    }
}