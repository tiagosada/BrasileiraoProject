using System;
using Xunit;
using Domain;

namespace Tests
{
    public class PlayerTest
    {
        [Fact]
        public void Should_contains_Player_Name()
        {
            var name = "Joao";
            var player = new Player(name);

           // Assert.Equal(name, player.Name);
            Assert.Equal(name, player.Name);
        }
        
    }
}
