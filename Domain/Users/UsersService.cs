using System;
using Domain.Common;
using System.Linq;

namespace Domain.Users
{
    public class UserService
    {
        private readonly UsersRepository _usersRepository = new UsersRepository();

        public CreatedUserDTO Create(
            string name,
            Profile profile,
            string email,
            string password
        )
        {
            var crypt = new Crypt();
            var cryptPassword = crypt.CreateMD5(password);
            
            var user = new User(name, cryptPassword, email, profile);
            var userValidation = user.Validate();

            if (userValidation.isValid)
            {
                _usersRepository.Add(user);
                return new CreatedUserDTO(user.Id);
            }

            return new CreatedUserDTO(userValidation.errors);
        }
        
        public User GetById(Guid id)
        {
            return _usersRepository.SearchForUserId(id);
        }
        public CreatedUserDTO Rename(string name, User target)
        {
            var user = new User(name, target.Password, target.Email, target.Profile);
            var userValidation = user.Validate();

            if (userValidation.isValid)
            {
                _usersRepository.Remove(target);
                _usersRepository.Add(user);
                return new CreatedUserDTO(target.Id);
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