using System;
using Xunit;
using Domain;

namespace Tests
{
    public class PlayerTest
    {
        [Theory]
        [InlineData("Joao", 1, 2)]
        public void Should_contains_Player_validname_position_and_goals(string name, int position, int goals)
        {
            var player = new Player(name, goals, position);

           // Assert.Equal(name, player.Name);
            Assert.True(player.ValidateName());
            Assert.Equal(goals, player.Goals);
            Assert.Equal(position, player.Position);
        }
        [Theory]
        [InlineData("", 0, 0)]
        public void Should_retuns_false_when_passed_a_invalid_name(string name, int position, int goals)
        {
            var player = new Player(name, goals, position);

           // Assert.Equal(name, player.Name);
            Assert.False(player.ValidateName());
            Assert.Equal(goals, player.Goals);
            Assert.Equal(position, player.Position);
        }
    }
}
