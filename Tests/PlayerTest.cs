using Xunit;
using Domain;

namespace Tests
{
    public class PlayerTest
    {
        [Fact]
        public void Should_create_a_Player()
        {
            var name = "John";

            var player = new Player(name);

            Assert.Equal(name, player.Name);
            Assert.NotNull(player.Id);
            Assert.Equal(0, player.Goals);
        }
        [Fact]
        public void Should_Make_a_Goal()
        {
            var name = "John";

            var player = new Player(name);
            player.GiveGoal();

            Assert.Equal(name, player.Name);
            Assert.NotNull(player.Id);
            Assert.Equal(1, player.Goals);
        }
        [Fact]
        public void Should_Make_3_Goals()
        {
            var name = "John";

            var player = new Player(name);
            player.GiveGoal();
            player.GiveGoal();
            player.GiveGoal();

            Assert.Equal(name, player.Name);
            Assert.NotNull(player.Id);
            Assert.Equal(3, player.Goals);
        }
        [Theory]
        [InlineData("J0n47h4n")]
        [InlineData("Jo   nathan")]
        [InlineData("Jonathan     ")]
        [InlineData("  Jonathan")]
        [InlineData("J%#!(#*n")]
        [InlineData("!4@!")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(" h")]
        [InlineData(" G")]
        [InlineData(null)]
        public void should_return_false_when_invalid_name(string name)
        {
            var player = new Player(name);

            var isValid = player.ValidateName();

            Assert.False(isValid);
        }

        [Theory]
        [InlineData("Jonathan")]
        [InlineData("JONATHAN")]
        public void should_return_true_when_valid_name(string name)
        {
            var player = new Player(name);

            var isValid = player.ValidateName();

            Assert.True(isValid);
        }
    }
}
