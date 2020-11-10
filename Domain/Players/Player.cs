using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Player
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }

        public int Goals { get; set; }
        //public string Position { get; set; }

        public Player(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
        public void GiveGoal()
        {
            this.Goals++;
        }
        public (List<string> errors, bool isValid) Validate()
        {
            var errs = new List<string>(); 
            
            if (!ValidateName())
            {
                errs.Add("Invalid name");
            }

            return (errs, errs.Count == 0);
        }

        private bool ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            var words = Name.Split(' ');
            if (words.Length < 1)
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
    }
}