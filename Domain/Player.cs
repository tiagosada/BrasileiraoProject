using System;
namespace Domain
{
    public class Player
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }

        //public int Goals { get; set; }
        //public string Position { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}