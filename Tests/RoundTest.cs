using Xunit;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    public class RoundTest
    {
        [Fact]
        public void Should_create_a_round()
        {
            var matches = Mock();

            var round = new Round(matches);

            Assert.NotEmpty(matches);
            Assert.Equal(matches.Count, round.Matches.Count);
            Assert.False(round.PlayedRound);
            
        }
        public List<Match> Mock()
        {
            var playersList = new List<Player>{
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

            var teamsList = new List<Team>{
            new Team("Flasco"),
            new Team("Palmeiras"),
            new Team("Vasco"),
            new Team("Flamengo"),
            new Team("Atlético"),
            new Team("BotaFogo"),
            new Team("Inter"),
            new Team("Gremio"),
            new Team("Barcelona"),
            new Team("Corintias")
            };

            foreach (var team in teamsList)
            {
                team.AddPlayersList(playersList);
            }

            var matchesList = new List<Match>{};

            for (int i = 0; i < teamsList.Count; i++)
            { 
                for (int j = 0 +i; j < teamsList.Count; j++)
                {
                    if(i != j)
                    {
                        matchesList.Add(new Match(teamsList[i], teamsList[j]) );
                    } 
                }
            }

            return matchesList;
            
        }
    }
}
