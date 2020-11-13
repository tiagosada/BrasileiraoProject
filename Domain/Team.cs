using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Team : TeamStatistics
    {
        public string TeamName { get; private set; }
        private List<Player> players { get; set; } = new List<Player>();
        public IReadOnlyCollection<Player> Players => players;
   
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
            players.Remove(Player);
            return true;
        }
        public bool AddPlayersList(List<Player> Players)
        {
            if (players.Count > 32 || Players.Count+players.Count >32)
            {
                return false;
            }

            this.players.AddRange(Players);
            return true;
        }
        public Player GetPlayerById(Guid playerId)
        {
            return Players.First(player => player.Id == playerId);
        }
        public Guid GetPlayerIdByName(string playerName)
        {
            return Players.First(player => player.Name == playerName).Id;
        }
    }
}