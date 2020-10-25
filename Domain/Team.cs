using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Team 
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string TeamName { get; private set; }
        private List<Player> players { get; set; } = new List<Player>();
        public IReadOnlyCollection<Player> Players => players;
        public TeamStatistics Table { get; set;} = new TeamStatistics();
   
        public Team(string name) 
        {
            TeamName = name;
            players = new List<Player>();      
        }
        public Team(string name, List<Player> playerslist) 
        {
            TeamName = name;
            players = playerslist;     
        }
         public Guid GetPlayerIdByName(string name)
        {
            return players.First(x => x.Name == name).Id;
        }
        public bool AddPlayer(Player Player)
        {
            if (players.Count >= 32 )
            {
                return false;
            }
            players.Add(Player);
            return true;
        }
        public bool RemovePlayer(Player Player)
        {
            if (players.Count <= 16)
            {
                return false;
            }

            players.Remove(Player);
            return true;
        }
        public bool AddPlayersList(List<Player> Players)
        {
            if (players.Count > 32 || Players.Count+players.Count >=32)
            {
                return false;
            }

            this.players.AddRange(Players);
            return true;
        }
        public void ScoreAGoal()
        {
            var random = new Random().Next(players.Count);
            players[random].GiveGoal();
            Table.ScoreMakedGoals();
            
        }
    }
}