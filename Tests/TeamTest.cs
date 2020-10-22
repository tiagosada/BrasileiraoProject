using Xunit;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class TeamTest
    {
        [Fact]
        public void Should_create_a_Team()
        {
            var name = "Flasco";

            var team = new Team(name);

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
        [Fact]
        public void Should_create_a_Team_with_a_player()
        {
            var name = "Flasco";

            var team = new Team(name);
            var addPlayer = team.AddPlayer(new TeamPlayer("Lucaos"));

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.NotEmpty(team.Players);
            Assert.Equal(1, team.Players.Count);
            Assert.True(addPlayer);
        }
        [Fact]
        public void Should_create_a_Team_with_16_players()
        {
            var name = "Flasco";

            var team = new Team(name);
            var addPlayerList = team.AddPlayersList(TeamPlayersList);

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.Equal(16, team.Players.Count);
            Assert.True(addPlayerList);
        }
        [Fact]
        public void Should_create_a_Team_with_a_player_and_remove()
        {
            var name = "Flasco";
            var player1 = new TeamPlayer("Lucaos");

            var team = new Team(name);
            var addPlayer = team.AddPlayer(player1);
            var addPlayerList = team.AddPlayersList(TeamPlayersList);

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.Equal(16, team.Players.Count);
            Assert.True(addPlayerList);
            Assert.True(addPlayer);
            
            var removePlayer = team.RemovePlayer(player1);

            Assert.True(removePlayer);
            Assert.Equal(16, team.Players.Count);
        }
        public List<TeamPlayer> TeamPlayersList {get; set;} = new List<TeamPlayer>{
                new TeamPlayer("Omar"),
                new TeamPlayer("Matheus"),
                new TeamPlayer("Raul"),
                new TeamPlayer("Ruan"),
                new TeamPlayer("Max"),
                new TeamPlayer("Marcos"),
                new TeamPlayer("Maicon"),
                new TeamPlayer("Paulo"),
                new TeamPlayer("Leandro"),
                new TeamPlayer("Richardi"),
                new TeamPlayer("Lucas"),
                new TeamPlayer("John"),
                new TeamPlayer("Sergio"),
                new TeamPlayer("Kaka"),
                new TeamPlayer("Iago"),
                new TeamPlayer("Tiago"),
                };
    }
}