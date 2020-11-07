using System;
using System.Linq;

namespace Domain.Users
{
    public class User
    {
        public Guid Id
        {get; set;} = Guid.NewGuid();

        public string Name
        {get; set;}

        public Profile Profile
        {get; set;}

        public User(string name, Profile profile)
        {
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
        public bool Validate()
        {
            if (ValidateProfile() && ValidateName())
            {
                return true;
            }
            return false;
        }

    }
}