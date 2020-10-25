using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Championship 
    {
        public bool championshipStart {get; protected set; } = false;
        public List<Match> Matches { get; private set; } = new List<Match>();
        public List<Round> Rounds { get; private set; } = new List<Round>();
        private List<Team> teams { get; set; } = new List<Team>();
        public int Round {get; private set;} = 0;

        public IReadOnlyCollection<Team> Teams => teams;

        public void CreateMatches(List<Team> teams)
        {
            var rand = new Random();
            
            for(int i = 0;i < teams.Count;i++)
            {
                var x = rand.Next(teams.Count);
                var temp = teams[i];
                teams[i] = teams[x];
                teams[x] = temp;
            }
            for (int i = 0; i < teams.Count; i++)
            { 
                for (int j = 0 +i; j < teams.Count; j++)
                {
                    if(i != j)
                    {
                        this.Matches.Add(new Match(teams[i], teams[j]) );
                    } 
                }
            }
        }
        public int RoundsNumber(List<Team> teams)
        {
            var roundsNumber = 0;
            var totalMatches = (teams.Count * (teams.Count-1)) / 2;
           
            for (int i = 10; i > 2; i--)
            {
                if (totalMatches % i == 0)
                {
                    roundsNumber = totalMatches / i;
                    break;
                }
            } 
            return roundsNumber;
        }
        public bool RoundGenerator()
        { 
            if (teams.Count < 8)
            {
                return false;
            }
            if (Matches.Count != RoundsNumber(teams))
            {
                return false;
            }
            if (Round == RoundsNumber(teams))
            {
                return false;
            }

            var RoundMatches = new List<Match>();
            
            for (int i = 0; i < Matches.Count/RoundsNumber(teams) ; i++)
            {
                var rand = new Random();
                var index = rand.Next(Matches.Count);
                RoundMatches.Add(Matches[index]);
                Matches.RemoveAt(index);
            }

            Rounds.Add(new Round(RoundMatches));
            Round++;

            return true;
        }

        public bool playRound(User user)
        {
            if(user.Profile.Equals("Torcedor"))
            {
                return false;
            }
            if (Rounds.Count.Equals(0))
            {
                return false;   
            }
            if (Round > RoundsNumber(teams))
            {
                return false;
            }

            var CurrentRound = Rounds.First( round => round.PlayedRound == false);
            
            foreach (var match in CurrentRound.Matches)
            {
               match.PlayMatch();
            }
            
            CurrentRound.PlayedRound = true;
            return true;
        }

        public List<Player> GetTopScorers()
        {
            var TopScorers = new List<Player>();

            foreach (var team in Teams)
            {
                TopScorers.AddRange(team.Players);
            }

            return TopScorers.OrderByDescending(player => player.Goals).ToList();
        }

        public bool ChampionshipStart(User user)
        {
            if(user.Profile.Equals("Torcedor"))
            {
                return false;
            }
            
            championshipStart = true;

            return true;
        } 

        public bool RegisterTeam(User user, List<Team> newteams)
        {
            if(user.Profile.Equals("Torcedor"))
            {
                return false;
            }
            else if(championshipStart == true)
            {
                return false;
            }
            else if(teams.Count < 7)
            {
                return false;
            }

            teams = newteams;
            championshipStart = true;
            return true;
        }

        public bool RemoveTeamPlayer(User user, Player player, Guid IdTeam)
        {
            if(user.Profile.Equals("Torcedor"))
            {
                return false;
            }

            teams.Find(x => x.Id == IdTeam).RemovePlayer(player);
            return true;
        }

        public bool AddPlayerTeam(User user, Player player, Guid IdTeam)
        {
            if(user.Profile.Equals("Torcedor"))
            {
                return false;
            }

            teams.Find(x => x.Id == IdTeam).AddPlayer(player);
            return true;
        }

        public List<Team> DisplayTable()
        {
            var TeamOrdered = teams.OrderByDescending(x => x.Table.Score).ThenByDescending(x => x.Table.GoalsDifference).ThenByDescending(x => x.Table.MakedGoals);
            
            return TeamOrdered.ToList();

        }
        public List<Team> QualifiedTeams()
        {
            var TeamOrdered = teams.OrderByDescending(x => x.Table.Score).ThenByDescending(x => x.Table.GoalsDifference).ThenByDescending(x => x.Table.MakedGoals);
            
            return TeamOrdered.Take(4).ToList();

        }
        public List<Team> DisqualifiedTeams()
        {
            var TeamOrdered = teams.OrderByDescending(x => x.Table.Score).ThenByDescending(x => x.Table.GoalsDifference).ThenByDescending(x => x.Table.MakedGoals);
            
            return TeamOrdered.TakeLast(4).ToList();

        }
        

        public List<Match> ShowResultRound()
        {
            var MatchesResult = new List<Match>();

            foreach (var round in Rounds)
            {
                if(round.PlayedRound)
                {
                    MatchesResult.AddRange(round.Matches);
                }
            }

            return MatchesResult;
        }
    }
}