using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Players;
using Domain.Teams;
namespace Domain.Teams
{
    public class Team : TeamStatistics
    {
        public string Name { get; private set; }

        public virtual List<Player> Players { get; set; } = new List<Player>();
   
        public Team(string name) 
        {
            Name = name; 
        }
        public Team(string name, List<Player> playerslist) 
        {
            Name = name;
            Players = playerslist;     
        }
        protected bool ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            var words = Name.Split(' ');

            foreach (var word in words)
            {
                if (word.Trim().Length < 2)
                {
                    return false;
                }
                if (word.Any(x => !char.IsLetter(x)))
                {
                    return false;
                }
            }

            return true;
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }
            return (errors, errors.Count == 0);
        }
        public bool AddPlayer(Player Player)
        {
            if (Players.Count >= 32 )
            {
                return false;
            }
            Players.Add(Player);
            return true;
        }
        public bool RemovePlayer(Player player)
        {
            Players.Remove(player);
            return true;
        }
        public bool AddPlayersList(List<Player> players)
        {
            if (players.Count > 32 || players.Count+Players.Count >32)
            {
                return false;
            }

            this.Players.AddRange(players);
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