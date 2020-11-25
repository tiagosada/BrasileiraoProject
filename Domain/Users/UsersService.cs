using System;
using System.Linq;

namespace Domain.Users
{
    public class UserService
    {
        private UsersRepository _usersRepository { get; set; } = new UsersRepository();
        public CreatedUserDTO Create(string name, string password, Profile profile)
        {
            var user = new User(name, password, profile);
            var userValidation = user.Validate();

            if (userValidation.isValid)
            {
                _usersRepository.Add(user);
                return new CreatedUserDTO();
            }
            return new CreatedUserDTO(userValidation.errors);
        }
        
        public CreatedUserDTO Rename(string name, User target)
        {
            var user = new User(name, target.Password, target.Profile);
            var userValidation = user.Validate();

            if (userValidation.isValid)
            {
                _usersRepository.Remove(target);
                _usersRepository.Add(user);
                return new CreatedUserDTO();
            }
            return new CreatedUserDTO(userValidation.errors);
        }
        public User FindUser(string name)
        {
            return _usersRepository.FindUser(name);
        }
        public User SearchForUserId(Guid id)
        {
            return _usersRepository.SearchForUserId(id);
        }
    }
}