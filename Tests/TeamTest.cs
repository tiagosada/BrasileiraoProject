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
            var addPlayer = team.AddPlayer(new Player("Lucaos"));

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.Equal(1, team.Players.Count);
            Assert.True(addPlayer);
        }
        [Fact]
        public void Should_create_a_Team_with_16_players()
        {
            var name = "Flasco";

            var team = new Team(name);
            var addPlayerList = team.AddPlayersList(PlayersList);

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.Equal(16, team.Players.Count);
            Assert.True(addPlayerList);
        }
        [Fact]
        public void Should_create_a_Team_with_a_player_and_remove()
        {
            var name = "Flasco";
            var player1 = new Player("Lucaos");

            var team = new Team(name);
            var addPlayer = team.AddPlayer(player1);
            var addPlayerList = team.AddPlayersList(PlayersList);

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.Equal(17, team.Players.Count);
            Assert.True(addPlayerList);
            Assert.True(addPlayer);
            
            var removePlayer = team.RemovePlayer(player1);

            Assert.True(removePlayer);
            Assert.Equal(16, team.Players.Count);
        }
        [Fact]
        public void Should_create_not_allow_to_add_a_playerList_if_is_gonna_be_more_than_32_players()
        {
            var name = "Flasco";
            var player1 = new Player("Lucaos");

            var team = new Team(name);
            var addPlayer = team.AddPlayer(player1);
            var addPlayerList = team.AddPlayersList(PlayersList);
            var addPlayerList2 = team.AddPlayersList(PlayersList2);

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.Equal(17, team.Players.Count);
            Assert.True(addPlayer);
            Assert.True(addPlayerList);
            Assert.False(addPlayerList2);
        }
        public void Should_create_not_allow_to_add_a_player_if_is_gonna_be_more_than_32_players()
        {
            var name = "Flasco";
            var player1 = new Player("Lucaos");

            var team = new Team(name);
            var addPlayerList = team.AddPlayersList(PlayersList);
            var addPlayerList2 = team.AddPlayersList(PlayersList2);
            var addPlayer = team.AddPlayer(player1);

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.Equal(32, team.Players.Count);
            Assert.True(addPlayerList2);
            Assert.True(addPlayerList);
            Assert.False(addPlayer);
        }
        [Fact]
        public void Should_create_a_Team_and_set_a_match()
        {
            var name = "Flasco";

            var team = new Team(name);
            team.Table.PlayMatch();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(1, team.Table.PlayedMatchs);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
        [Fact]
        public void Should_create_a_Team_and_set_a_Win()
        {
            var name = "Flasco";

            var team = new Team(name);
            team.Table.ScoreWin();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(1, team.Table.Wins);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
        [Fact]
        public void Should_create_a_Team_and_set_a_Defeat()
        {
            var name = "Flasco";

            var team = new Team(name);
            team.Table.ScoreDefeat();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(1, team.Table.Defeats);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
        public void Should_create_a_Team_and_set_a_Draw()
        {
            var name = "Flasco";

            var team = new Team(name);
            team.Table.ScoreDraw();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(1, team.Table.Draws);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
        public void Should_create_a_Team_and_set_a_ConcededGoals()
        {
            var name = "Flasco";

            var team = new Team(name);
            team.Table.ScoreConcededGoals();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(1, team.Table.ConcededGoals);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
        public void Should_create_a_Team_and_set_a_MakedGoals()
        {
            var name = "Flasco";

            var team = new Team(name);
            team.Table.ScoreMakedGoals();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(1, team.Table.MakedGoals);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
        public void Should_create_a_Team_and_set_Score_3()
        {
            var name = "Flasco";

            var team = new Team(name);
            team.Table.ScoreWin();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(3, team.Table.Score);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
        public void Should_create_a_Team_and_set_Score_1()
        {
            var name = "Flasco";

            var team = new Team(name);
            team.Table.ScoreDraw();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(1, team.Table.Score);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
        public void Should_create_a_Team_set_match_set_Score_3_and_UpdateRate()
        {
            var name = "Flasco";

            var team = new Team(name);
            team.Table.PlayMatch();
            team.Table.ScoreWin();
            team.Table.UpdateRate();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(3, team.Table.Score);
            Assert.Equal(100, team.Table.Rate);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
//      <~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ MOCKS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
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
            new Player("Legolas"),
            new Player("Azhagal"),
            new Player("Ottoni"),
            new Player("Grah"),
            new Player("Vandir"),
            new Player("Ney"),
            new Player("Ronaldo"),
            new Player("Roberto"),
            new Player("Carlos"),
            new Player("Fumadim"),
            new Player("Leonidas"),
            new Player("Ranger"),
            new Player("Ronaldinho Gaúcho"),
            new Player("Lauricio"),
            new Player("Caco"),
            new Player("Patati"),
        };      
    }
}