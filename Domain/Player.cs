using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;

>>>>>>> ccf8f61... adding PlayerTests
namespace Domain
{
    public class Player
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }

<<<<<<< HEAD
        //public int Goals { get; set; }
        //public string Position { get; set; }

        public Player(string name)
=======
        public Player(string name, int goals, int position)
        {
            this.Id = Guid.NewGuid();

            this.Goals = goals;

            this.Position = position;

            this.Name = name;

            if (!this.ValidateName())
            {
                this.Name = null;
            }
        }
        public string PlayerPosition( int position)
>>>>>>> ccf8f61... adding PlayerTests
        {
            Name = name;
        }
        public bool ValidateName()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                return false;
            }
            if (!Name.All(x => char.IsLetter(x) || char.IsWhiteSpace(x)))
            {
                return false;
            }
            if (!char.IsUpper(Name[0]))
            {
                return false;
            }
            return true;
            
        }
    }
}