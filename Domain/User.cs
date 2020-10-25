using System;
using System.Collections.Generic;

namespace Domain
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Profile { get; private set; }

        public User(string name, string profile)
        {
            Name = name;
            Profile = profile;
        }
    }
}
