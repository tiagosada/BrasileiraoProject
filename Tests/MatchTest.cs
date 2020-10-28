using Xunit;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class MatchTest
    {
        [Fact]
        public void Should_create_a_Match()
        {
            var teamslistmethod = TeamsWithPlayersList();

            var match = new Match(teamslistmethod[0], teamslistmethod[1]);

            match.PlayMatch(NamesListMock(1,0), NamesListMock(2,0));
            

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
        [Fact]
        public void Should_create_a_Match_and_score_a_goal_for_hometeam()
        {
            var teamslistmethod = TeamsWithPlayersList();

            var match = new Match(teamslistmethod[0], teamslistmethod[1]);
            match.PlayMatch(NamesListMock(1,1), NamesListMock(2,0));

            Assert.NotNull(match.Id);
            Assert.Equal(teamslistmethod[0], match.HomeTeam);
            Assert.Equal(teamslistmethod[1], match.VisitingTeam);
            Assert.Equal(1, match.HomeTeamGoals);
            Assert.Equal(1, match.HomeTeam.Table.MakedGoals);
            Assert.Equal(0, match.HomeTeam.Table.ConcededGoals);
            Assert.Equal(1, match.HomeTeam.Table.Wins);
            Assert.Equal(0, match.VisitingTeamGoals);
            Assert.Equal(0, match.VisitingTeam.Table.MakedGoals);
            Assert.Equal(1, match.VisitingTeam.Table.ConcededGoals);
            Assert.Equal(1, match.VisitingTeam.Table.Defeats);
        }
        [Fact]
        public void Should_create_a_Match_and_score_a_goal_for_visitingteam()
        {
            var teamslistmethod = TeamsWithPlayersList();

            var match = new Match(teamslistmethod[0], teamslistmethod[1]);
            match.PlayMatch(NamesListMock(1,0), NamesListMock(2,1));

            Assert.NotNull(match.Id);
            Assert.Equal(teamslistmethod[0], match.HomeTeam);
            Assert.Equal(teamslistmethod[1], match.VisitingTeam);
            Assert.Equal(0, match.HomeTeamGoals);
            Assert.Equal(0, match.HomeTeam.Table.MakedGoals);
            Assert.Equal(1, match.HomeTeam.Table.ConcededGoals);
            Assert.Equal(1, match.HomeTeam.Table.Defeats);
            Assert.Equal(1, match.VisitingTeamGoals);
            Assert.Equal(1, match.VisitingTeam.Table.MakedGoals);
            Assert.Equal(0, match.VisitingTeam.Table.ConcededGoals);
            Assert.Equal(1, match.VisitingTeam.Table.Wins);

        }

//       <~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Mocks~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
        public List<Team> TeamsWithPlayersList()
        {
            
            TeamsList[0].AddPlayersList(PlayersList);

            TeamsList[1].AddPlayersList(PlayersList2);


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
        public List<Player> PlayersList2 {get; set;} = new List<Player>
            {
                new Player("Azul"),
                new Player("Ateu"),
                new Player("Abalado"),
                new Player("Atunir"),
                new Player("Aldair"),
                new Player("Atum"),
                new Player("Alcemar"),
                new Player("Alcides"),
                new Player("Alceu"),
                new Player("Alcione"),
                new Player("Among"),
                new Player("Ajuju"),
                new Player("Ajudante"),
                new Player("Aberração"),
                new Player("Arbitro"),
                new Player("Ambito"),
            };
        
        public List<string> NamesListMock(int list,int amount)
        {
            if (list == 1)
            {
                return PlayerNames.Take(amount).ToList();
            }
            else if (list == 2)
            {
                return PlayerNames2.Take(amount).ToList();
            }


            return PlayerNames;
        }
        public List<string> PlayerNames {get ; set;} = new List<string>{
            "Omar",
            "Matheus",
            "Raul",
            "Ruan",
            "Max",
            "Marcos",
            "Maicon",
            "Paulo",
            "Leandro",
            "Richardi",
            "Lucas",
            "John",
            "Sergio",
            "Kaka",
            "Iago",
            "Tiago"
        };
        public List<string> PlayerNames2 {get ; set;} = new List<string>{
            "Azul",
            "Ateu",
            "Abalado",
            "Atunir",
            "Aldair",
            "Atum",
            "Alcemar",
            "Alcides",
            "Alceu",
            "Alcione",
            "Among",
            "Ajuju",
            "Ajudante",
            "Aberração",
            "Arbitro",
            "Ambito"
        };
    }
}