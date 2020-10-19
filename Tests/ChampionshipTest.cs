using System;
using Xunit;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    public class ChampionshipTest
    {
        [Fact]
        public void Should_register_user_CBF()
        {
            var champ = new Championship();
            var user = new User("João da Silva", "CBF");
            var password = "cbffoda";
            var userInfo = new List<User>{user};
            
            var expected = champ.CreateUsers(userInfo, password);

            Assert.NotNull(champ.User);
            Assert.True(expected);
        }

        [Fact]
        public void Should_register_user_torcedor()
        {
            var champ = new Championship();
            var user = new User("Pedro Tavares", "Torcedor");
            var password = "cbffoda";
            var userInfo = new List<User>{user};
            
            var expected = champ.CreateUsers(userInfo, password);

            Assert.NotNull(champ.User);
            Assert.True(expected);
        }

        [Fact]
        public void Should_Not_register_user_torcedor()
        {
            var champ = new Championship();
            var user = new User("Pedro Tavares", "Torcedor");
            var password = "incorreto";
            var userInfo = new List<User>{user};
            
            var expected = champ.CreateUsers(userInfo, password);

            Assert.Null(champ.User);
            Assert.False(expected);
        }

        [Fact]
        public void Should_register_team()
        {
            var champ = new Championship();
            var nameTeam = new Team("Palmeiras");
            var profile = "CBF";
            var teamInfo = new List<Team>{nameTeam};
            
            var expected = champ.CreateTeam(teamInfo, profile);

            Assert.NotNull(champ.Team);
            Assert.True(expected);
        }

        [Fact]
        public void Should_register_player()
        {
            var champ = new Championship();
            var name = new Player("Pedro");
            var profile = "CBF";
            var playerInfo = new List<Player>{name};
            
            var expected = champ.CreatePlayer(playerInfo, profile);

            Assert.NotNull(champ.Player);
            Assert.True(expected);
        }
    }
}