using System;

namespace Domain
{
    public class Team 
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        //public List<Jogador> Jogadores { get; set; }
        public int Score { get; set; }
        public int Matchs { get; set; }
        public int Wins { get; set; }
        public int Draw { get; set; }
        public int Defeats { get; set; }
        public int Goals { get; set; }
        public int MakedGoals { get; set; }
        public int ConcededGoals { get; set; }
   
        public Team(string name) 
            {
                Name = name;       
            }

    }
}