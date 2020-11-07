using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Users;

namespace Domain
{
    public class Championship 
    {
//     <~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~[Proprieties]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

        public bool championshipStart {get; protected set; } = false;
        public List<Match> Matches { get; private set; } = new List<Match>();
        public Match CurrentMatch { get; private set; }
        public List<Round> Rounds { get; private set; } = new List<Round>();
        private List<Team> teams { get; set; } = new List<Team>();
        public int Round {get; private set;} = 0;
        public bool RoundStarted {get; private set;} = false;
        public IReadOnlyCollection<Team> Teams => teams;
        public User CurrentUser {get; private set;} //remover
        public int MatchesPerRounds {get; private set;}

//     <~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~[Register]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

        public bool RegisterUser(string name, Profile profile, string password)
        {
            if (password != "admin123")
            {
                return false;
            }
            CurrentUser = new User(name, profile);
            return true;
        }
        public bool RegisterUser(string name)
        {
            CurrentUser = new User(name, Profile.Supporter);
            return true;
        }


        public bool RegisterTeams(List<Team> newteams)
        {
            if(CurrentUser.Profile != Profile.CBF)
            {
                return false;
            }
            else if(championshipStart == true)
            {
                return false;
            }
            

            teams = newteams;
            return true;
        }
        public bool RemovePlayer(Player player, Guid IdTeam)
        {
            if(CurrentUser.Profile != Profile.CBF)
            {
                return false;
            }
            if(teams.Count < 0)
            {
                return false;
            }

            teams.Find(x => x.Id == IdTeam).RemovePlayer(player);
            return true;
        }

        public bool AddPlayer(Player player, Guid IdTeam)
        {
            if(CurrentUser.Profile != Profile.CBF)
            {
                return false;
            }

            teams.Find(x => x.Id == IdTeam).AddPlayer(player);
            return true;
        }
        public bool CreateMatches()
        {
            if(CurrentUser.Profile != Profile.CBF)
            {
                return false;
            }
            if(teams.Count < 8)
            {
                return false;
            }

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
                        Matches.Add(new Match(teams[i], teams[j]) );
                    } 
                }
            }
            MatchesPerRounds = CalculateMatchesPerRounds();
            return true;
        }
        private int RoundsNumber()
        {
            var roundsNumber = 0;
            var totalMatches = (teams.Count * (teams.Count-1)) / 2;
           
            for (int i = 10; i > 2; i--)
            {
                if (totalMatches % i == 0)
                {
                    roundsNumber = i;
                    break;
                }
            } 
            return roundsNumber;
        }
        private int CalculateMatchesPerRounds()
        {
            var matchesPerRounds = 0;
            var totalMatches = (teams.Count * (teams.Count-1)) / 2;
           
            for (int i = 10; i > 2; i--)
            {
                if (totalMatches % i == 0)
                {
                    matchesPerRounds = totalMatches / i;
                    break;
                }
            } 
            return matchesPerRounds;
        }
        public bool RoundGenerator()
        { 
            if(CurrentUser.Profile != Profile.CBF)
            {
                return false;
            }
            if (teams.Count < 8)
            {
                return false;
            }
            if (Matches.Count % MatchesPerRounds != 0)
            {
                return false;
            }
            if (Matches.Count == 0)
            {
                return false;
            }
            if (Round == RoundsNumber())
            {
                return false;
            }

            var RoundMatches = new List<Match>();
            
            for (int i = 0; i < MatchesPerRounds ; i++)
            {
                var index = new Random().Next(Matches.Count);
                RoundMatches.Add(Matches[index]);
                Matches.RemoveAt(index);
            }

            Rounds.Add(new Round(RoundMatches));
            Round++;

            return true;
        }
        public Match FindCurrentMatch()
        {
            if(CurrentUser.Profile != Profile.CBF)
            {
                return null;
            }

            var CurrentRound = Rounds.FirstOrDefault( round => round.PlayedRound == false);
            if (CurrentRound == null)
            {
                return null;
            }
            CurrentMatch = CurrentRound.Matches.FirstOrDefault( match => match.VisitingTeamGoals == null );

            return CurrentMatch;          
        }


        public bool SetMatchResult(List<string> HplayerGoals, List<string> VplayerGoals)
        {
            if(CurrentUser.Profile != Profile.CBF)
            {
                return false;
            }   

            var CurrentRound = Rounds.FirstOrDefault( round => round.PlayedRound == false);
            if (CurrentRound == null)
            {
                return false;
            }
            var currentMatch = CurrentRound.Matches.FirstOrDefault( match => match.VisitingTeamGoals == null );
            if (currentMatch == null)
            {
                return false;
            }
            
            currentMatch.PlayMatch(HplayerGoals, VplayerGoals);


            if (CurrentRound.Matches.All(match => match.VisitingTeamGoals != null))
            {
                CurrentRound.PlayedRound = true;
            }
            return true;
        }
        public bool SetMatchResult()
        {
            if(CurrentUser.Profile != Profile.CBF)
            {
                return false;
            }
            

            var CurrentRound = Rounds.First( round => round.PlayedRound == false);
            
            var currentMatch = CurrentRound.Matches.First( match => match.VisitingTeamGoals == null );
            
            currentMatch.PlayMatch();


            if (CurrentRound.Matches.All(match => match.VisitingTeamGoals != null))
            {
                CurrentRound.PlayedRound = true;
            }
            return true;
        }
        public bool ChampionshipStart(User user)
        {
            if(CurrentUser.Profile != Profile.CBF)
            {
                return false;
            }
            
            championshipStart = true;

            return true;
        } 

//     <~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~[Showing]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

        public List<Player> GetTopScorers()
        {
            var TopScorers = new List<Player>();

            foreach (var team in Teams)
            {
                TopScorers.AddRange(team.Players);
            }

            return TopScorers.OrderByDescending(player => player.Goals).ToList();
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
        public List<Match> ShowRoundResult()
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
       
        public Team GetTeamById(Guid teamId)
        {
            return Teams.First(team => team.Id == teamId);
        }
        public Guid GetTeamIdByName(string teamName)
        {
            return Teams.First(team => team.TeamName == teamName).Id;
        }
    }
}