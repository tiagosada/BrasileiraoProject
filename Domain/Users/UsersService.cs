using System;
using System.Linq;

namespace Domain.Users
{
    public class UserService
    {
        public CreatedUserDTO Create(string name, string password, Profile profile)
        {
            var user = new User(name, password, profile);
            var userValidation = user.Validate();

            if (userValidation.isValid)
            {
                UserRepository.Add(user);
                return new CreatedUserDTO();
            }
            return new CreatedUserDTO(userValidation.errors);
        }
        public User FindUser(string name)
        {
            return UserRepository.FindUser(name);
        }
    }
}