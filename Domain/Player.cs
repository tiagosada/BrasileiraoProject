using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Player
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Goals { get; set; }
        public int Position { get; set; }

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
        {
            var Positions = new List<string>{
                "Goalkeeper", "Midfielder", "Attacker", "Fullback", "Center", "Striker", "Wingers"
            };
            if (position < 0 || position > Positions.Count)
            {
                position = 0;
            }
            return Positions[position] ;
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