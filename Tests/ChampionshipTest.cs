using System;
using Xunit;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    public class ChampionshipTest
    {
        [Fact]
        public void Deve_Cadastrar_CBF()
        {
            var champ = new Championship();
            var user = new User("João da Silva", "CBF");
            var password = "cbffoda";
            var userInfo = new List<User>{user};
            
            var expected = champ.CreateUsers(userInfo, password);

            Assert.NotNull(champ.User);
            Assert.True(expected);
        }
    }
}