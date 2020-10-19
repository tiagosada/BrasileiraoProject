using System;

namespace Domain
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Perfil { get; private set; }

        public User(string name, string perfil)
        {
            Name = name;
            Perfil = perfil;
        }
    }
}
