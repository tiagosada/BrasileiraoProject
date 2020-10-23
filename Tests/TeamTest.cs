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
        [Fact]
        public void Should_create_not_allow_to_add_a_playerList_if_is_gonna_be_more_than_32_players()
        {
            var name = "Flasco";
            var player1 = new TeamPlayer("Lucaos");

            var team = new Team(name);
            var addPlayer = team.AddPlayer(player1);
            var addPlayerList = team.AddPlayersList(TeamPlayersList);
            var addPlayerList2 = team.AddPlayersList(TeamPlayersList2);

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.Equal(16, team.Players.Count);
            Assert.True(addPlayer);
            Assert.True(addPlayerList);
            Assert.False(addPlayerList2);
        }
        public void Should_create_not_allow_to_add_a_player_if_is_gonna_be_more_than_32_players()
        {
            var name = "Flasco";
            var player1 = new TeamPlayer("Lucaos");

            var team = new Team(name);
            var addPlayerList = team.AddPlayersList(TeamPlayersList);
            var addPlayerList2 = team.AddPlayersList(TeamPlayersList2);
            var addPlayer = team.AddPlayer(player1);

            Assert.Equal(name, team.TeamName);
            Assert.NotNull(team.Id);
            Assert.Equal(16, team.Players.Count);
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
            team.Table.SetScore();

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
            team.Table.SetScore();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(1, team.Table.Score);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
        public void Should_create_a_Team_set_match_set_Score_3_and_AtualizeRate()
        {
            var name = "Flasco";

            var team = new Team(name);
            team.Table.PlayMatch();
            team.Table.ScoreWin();
            team.Table.SetScore();
            team.Table.AtualizeRate();

            Assert.Equal(name, team.TeamName);
            Assert.Equal(3, team.Table.Score);
            Assert.Equal(100, team.Table.Rate);
            Assert.NotNull(team.Id);
            Assert.Empty(team.Players);
        }
//      <~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ MOCKS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
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
        public List<TeamPlayer> TeamPlayersList2 {get; set;} = new List<TeamPlayer>
        {
            new TeamPlayer("Legolas"),
            new TeamPlayer("Azhagal"),
            new TeamPlayer("Ottoni"),
            new TeamPlayer("Grah"),
            new TeamPlayer("Vandir"),
            new TeamPlayer("Ney"),
            new TeamPlayer("Ronaldo"),
            new TeamPlayer("Roberto"),
            new TeamPlayer("Carlos"),
            new TeamPlayer("Richardi"),
            new TeamPlayer("Leonidas"),
            new TeamPlayer("Ranger"),
            new TeamPlayer("Ronaldinho Gaúcho"),
            new TeamPlayer("Lauricio"),
            new TeamPlayer("Caco"),
            new TeamPlayer("Patati"),
        };      
    }
}