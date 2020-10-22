using Xunit;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class TeamTest
    {
        // [Fact]
        // public void Should_contains_team_information()
        // {
        //     var name = "Flasco";
            
        //     var flasco = new Team(name);

        //     flasco.Score+= 100;
        //     flasco.Matchs+= 3;
        //     flasco.Wins+= 3;
        //     flasco.Draws+= 0;
        //     flasco.Defeats+= 0;
        //     flasco.Goals+= 5;
        //     flasco.ConcededGoals+= 0;
        //     flasco.PercentageExploitetion+= 100;

        //     Assert.NotNull(flasco.Id);
        //     Assert.Equal(name, flasco.Name);
        //     Assert.Equal(100, flasco.Score);
        //     Assert.Equal(3, flasco.Matchs);
        //     Assert.Equal(3, flasco.Wins);
        //     Assert.Equal(0, flasco.Draws);
        //     Assert.Equal(0, flasco.Defeats);
        //     Assert.Equal(5, flasco.Goals);
        //     Assert.Equal(0, flasco.ConcededGoals);
        //     Assert.Equal(100, flasco.PercentageExploitetion);
        // }

        // [Fact]
        // public void Should_simulate_a_match()
        // {
        //     var teams = TeamsList(3);
        //     var Id = teams[0].Id;

        //     var TeamFound = teams.FirstOrDefault(team => team.Id == Id);
        //     TeamFound.AddMatch(true);
        //     TeamFound.AddScore(250);
        //     TeamFound.DecreaseScore(100);

        //     Assert.NotNull(TeamFound.Id);
        //     Assert.Equal(teams[0].Name, TeamFound.Name);
        //     Assert.Equal(1, TeamFound.Matchs);
        //     Assert.Equal(150, TeamFound.Score);
        // }
        
        // public List<Team> TeamsList(int amount)
        // {
        //     var teamsList = new List<Team>()
        //     { 
        //         new Team("Flasco"),
        //         new Team("Grenal"),
        //         new Team("Flumineiras"),
        //         new Team("Bota Corgos")
        //     };
            
        //     if (amount > teamsList.Count())
        //     {
        //         amount = teamsList.Count();
        //     }
        //     else if (amount < 1)
        //     {
        //         amount = 1;
        //     }
        //     return teamsList.Take(amount).ToList();
        // }
    }
}