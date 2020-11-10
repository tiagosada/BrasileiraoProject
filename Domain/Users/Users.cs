using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Users
{
    public class User
    {
        public Guid Id
        {get; set;} = new Guid();

        public string Name
        {get; set;}

        public Profile Profile
        {get; set;}

        public User(string name, Profile profile)
        {
            Id = Guid.NewGuid();
            Name = name;
            Profile = profile;
        }
        private bool ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            var words = Name.Split(' ');
            if (words.Length < 2)
            {
                return false;
            }

            foreach (var word in words)
            {
                if (word.Trim().Length < 2)
                {
                    return false;
                }
                if (word.Any(x => !char.IsLetter(x)))
                {
                    return false;
                }
            }


            return true;
        }
        private bool ValidateProfile()
        {
            if (Profile != Profile.CBF && Profile != Profile.Supporter)
            {
                return false;
            }
            return true;
        }
        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }
            if (!ValidateProfile())
            {
                errors.Add("Perfil inválido.");
            }
            return (errors, errors.Count == 0);
        }
    }
}