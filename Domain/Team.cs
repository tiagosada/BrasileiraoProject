using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Team 
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string TeamName { get; private set; }
        private List<TeamPlayer> players { get; set; } = new List<TeamPlayer>();
        public IReadOnlyCollection<TeamPlayer> Players => players;
        public TeamStatistics Table { get; set;}
   
        public Team(string name) 
        {
            TeamName = name;
            players = new List<TeamPlayer>();
            Id = Guid.NewGuid();       
        }
         public Guid GetPlayerIdByName(string name)
        {
            return players.First(x => x.Name == name).Id;
        }
        public bool AddPlayer(TeamPlayer teamPlayer)
        {
            if (players.Count > 32 )
            {
                return false;
            }
            players.Add(teamPlayer);
            return true;
        }
        public bool RemovePlayer(TeamPlayer teamPlayer)
        {
            if (players.Count < 16)
            {
                return false;
            }

            players.Remove(teamPlayer);
            return true;
        }
        public bool AddPlayersList(List<TeamPlayer> teamPlayers)
        {
            if (players.Count > 32 && teamPlayers.Count+players.Count <=32)
            {
                return false;
            }

            this.players = teamPlayers;
            return true;
        }
    }
}