using System.Linq;
using Domain.Entities;

namespace Domain.People
{
    public abstract class Person : Entity
    {
        public string Name { get; protected set; }
        
        public Person(string name)
        {
            Name = name;
        }
        protected bool ValidateName()
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
    }
}