using System;

namespace Domain
{
    public class Spectator
    {
        public Spectator(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}