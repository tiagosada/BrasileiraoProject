using System.Collections.Generic;

namespace Domain
{
    public class Championship
    {
        private  List<Team> _team {get; set;}
        private  List<Player> _player {get; set;}
        
        public IReadOnlyCollection<Team> Team => _team;
        public IReadOnlyCollection<Player> Player => _player;

        public Championship()
        {
            var _team = new List<Team>();
            var _player = new List<Player>();
        }
        

        public bool CreateTeam(List<Team> nameTeam, string profile)
        {
            if(profile != "CBF" || nameTeam == null)
            {
                return false;
            }

            _team = nameTeam;
            return true;
        }

        public bool CreatePlayer(List<Player> name, string profile)
        {
            if(profile != "CBF" || name == null)
            {
                return false;
            }

            _player = name;
            return true;
        }
    }
}