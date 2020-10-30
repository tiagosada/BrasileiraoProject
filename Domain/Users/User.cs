using System;
using System.Collections.Generic;

namespace Domain.Users
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public bool CBF { get; private set; }

        public User(string name, string password)
        {
            Name = name;
            if (password == "Pa$Sw0rD")
            {
                CBF = true;
            }
            else
            {
                CBF = false;
            }
        }
        public User(string name)
        {
            Name = name;
            CBF = false;
        }
    }
}
