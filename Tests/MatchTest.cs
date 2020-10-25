using Xunit;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    public class MatchTest
    {
        public void Should_create_a_Match()
        {
            var teamslistmethod = TeamsWithPlayersList();

            var match = new Match(teamslistmethod[0], teamslistmethod[1]);

            Assert.NotNull(match.Id);
            Assert.Equal(teamslistmethod[0], match.HomeTeam);
            Assert.Equal(teamslistmethod[1], match.VisitingTeam);
            Assert.Equal(0, match.HomeTeamGoals);
            Assert.Equal(0, match.HomeTeam.Table.MakedGoals);
            Assert.Equal(0, match.HomeTeam.Table.ConcededGoals);
            Assert.Equal(0, match.VisitingTeamGoals);
            Assert.Equal(0, match.VisitingTeam.Table.MakedGoals);
            Assert.Equal(0, match.VisitingTeam.Table.ConcededGoals);

        }
        public void Should_create_a_Match_and_score_a_goal_for_hometeam()
        {
            var teamslistmethod = TeamsWithPlayersList();

            var match = new Match(teamslistmethod[0], teamslistmethod[1]);
            match.ScoreGoalsHomeTeam(1);

            Assert.NotNull(match.Id);
            Assert.Equal(teamslistmethod[0], match.HomeTeam);
            Assert.Equal(teamslistmethod[1], match.VisitingTeam);
            Assert.Equal(1, match.HomeTeamGoals);
            Assert.Equal(1, match.HomeTeam.Table.MakedGoals);
            Assert.Equal(0, match.HomeTeam.Table.ConcededGoals);
            Assert.Equal(0, match.VisitingTeamGoals);
            Assert.Equal(0, match.VisitingTeam.Table.MakedGoals);
            Assert.Equal(1, match.VisitingTeam.Table.ConcededGoals);

        }
        public void Should_create_a_Match_and_score_a_goal_for_visitingteam()
        {
            var teamslistmethod = TeamsWithPlayersList();

            var match = new Match(teamslistmethod[0], teamslistmethod[1]);
            match.ScoreGoalsVisitingTeam(1);

            Assert.NotNull(match.Id);
            Assert.Equal(teamslistmethod[0], match.HomeTeam);
            Assert.Equal(teamslistmethod[1], match.VisitingTeam);
            Assert.Equal(0, match.HomeTeamGoals);
            Assert.Equal(0, match.HomeTeam.Table.MakedGoals);
            Assert.Equal(1, match.HomeTeam.Table.ConcededGoals);
            Assert.Equal(1, match.VisitingTeamGoals);
            Assert.Equal(1, match.VisitingTeam.Table.MakedGoals);
            Assert.Equal(0, match.VisitingTeam.Table.ConcededGoals);

        }
        public void Should_create_a_Match_and_play_it_controled()
        {
            var teamslistmethod = TeamsWithPlayersList();

            var match = new Match(teamslistmethod[0], teamslistmethod[1]);

            match.PlayMatch(2,1);

            Assert.NotNull(match.Id);
            Assert.Equal(teamslistmethod[0], match.HomeTeam);
            Assert.Equal(teamslistmethod[1], match.VisitingTeam);
            Assert.Equal(2, match.HomeTeamGoals);
            Assert.Equal(2, match.HomeTeam.Table.MakedGoals);
            Assert.Equal(1, match.HomeTeam.Table.ConcededGoals);

            Assert.Equal(1, match.HomeTeam.Table.Wins);
            Assert.Equal(1, match.HomeTeam.Table.PlayedMatchs);
            Assert.Equal(0, match.HomeTeam.Table.Defeats);
            Assert.Equal(0, match.HomeTeam.Table.Draws);


            Assert.Equal(1, match.VisitingTeamGoals);
            Assert.Equal(1, match.VisitingTeam.Table.MakedGoals);
            Assert.Equal(2, match.VisitingTeam.Table.ConcededGoals);
            
            Assert.Equal(0, match.VisitingTeam.Table.Wins);
            Assert.Equal(1, match.VisitingTeam.Table.PlayedMatchs);
            Assert.Equal(1, match.VisitingTeam.Table.Defeats);
            Assert.Equal(0, match.VisitingTeam.Table.Defeats);


        }
        public void Should_create_a_Match_and_play_it_random()
        {
            var teamslistmethod = TeamsWithPlayersList();

            var match = new Match(teamslistmethod[0], teamslistmethod[1]);

            match.PlayMatch();

            Assert.NotNull(match.Id);
            Assert.Equal(teamslistmethod[0], match.HomeTeam);
            Assert.Equal(teamslistmethod[1], match.VisitingTeam);
            Assert.NotNull(match.HomeTeamGoals);
            Assert.NotNull(match.VisitingTeamGoals);

        }


        public List<Team> TeamsWithPlayersList()
        {
            foreach (var team in TeamsList)
            {
                team.AddPlayersList(PlayersList);
            } 
            return TeamsList;
        }
        public List<Team> TeamsList {get; set;} = new List<Team>{
            new Team("Flasco"),
            new Team("Corintias")
        };
        public List<Player> PlayersList {get; set;} = new List<Player>{
            new Player("Omar"),
            new Player("Matheus"),
            new Player("Raul"),
            new Player("Ruan"),
            new Player("Max"),
            new Player("Marcos"),
            new Player("Maicon"),
            new Player("Paulo"),
            new Player("Leandro"),
            new Player("Richardi"),
            new Player("Lucas"),
            new Player("John"),
            new Player("Sergio"),
            new Player("Kaka"),
            new Player("Iago"),
            new Player("Tiago"),
        };
    }
}