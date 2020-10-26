using Xunit;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    public class ChampionshipTest
    {
        [Fact]
        public void Should_Create_Championship()
        {
            
            var champ = new Championship();

            Assert.False(champ.championshipStart);
            Assert.Empty(champ.Matches);
            Assert.Empty(champ.Teams);
            Assert.Empty(champ.Rounds);
            Assert.Equal(0, champ.Round);
            
        }
        [Fact]
        public void Should_Register_User_CBF_on_Championship()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");

            Assert.Equal("Tiago", champ.CurrentUser.Name);
            Assert.True(champ.CurrentUser.CBF);
            Assert.NotNull(champ.CurrentUser.Id);
        }
        [Fact]
        public void Should_Register_User_not_CBF_on_Championship()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago");

            Assert.Equal("Tiago", champ.CurrentUser.Name);
            Assert.False(champ.CurrentUser.CBF);
            Assert.NotNull(champ.CurrentUser.Id);
        }
        [Fact]
        public void Should_Register_User_not_CBF_on_Championship2()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "password");

            Assert.Equal("Tiago", champ.CurrentUser.Name);
            Assert.False(champ.CurrentUser.CBF);
            Assert.NotNull(champ.CurrentUser.Id);
        }
        [Fact]
        public void Should_Register_Teams_on_Championship()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();

//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");            
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            var tryRegist = champ.RegisterTeams(champ.CurrentUser, TeamsMock());

            Assert.Equal(TeamsMock().Count, champ.Teams.Count);
            Assert.True(tryRegist);
        }
        [Fact]
        public void Should_not_Register_Teams_on_Championship_reason_not_CBF()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();

//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago");            
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            var tryRegist = champ.RegisterTeams(champ.CurrentUser, TeamsMock());

            Assert.Equal(0, champ.Teams.Count);
            Assert.False(tryRegist);
        }
        [Fact]
        public void Should_not_Register_Teams_on_Championship_reason_Championship_Started()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();

//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");       
            champ.ChampionshipStart(champ.CurrentUser);     
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            var tryRegist = champ.RegisterTeams(champ.CurrentUser, TeamsMock());

            Assert.Equal(0, champ.Teams.Count);
            Assert.False(tryRegist);
        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_add_a_Player()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterTeams(champ.CurrentUser, TeamsMock());
//      <~~~~~~~~~~~~~~~~~~~~~~~[Add Player to Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamId = champ.GetTeamIdByName("Flasco");

            var tryAdd =champ.AddPlayer(champ.CurrentUser, new Player("Leozim"), teamId);

            var playerId = champ.GetPlayerIdByName("Leozim", teamId);
            var findedPlayer = champ.GetPlayerById(playerId, teamId);
            var findedTeam = champ.GetTeamById(teamId);
            
            Assert.True(tryAdd);
            Assert.Equal(findedTeam.Players.Count+1, findedTeam.Players.Count);
            Assert.Equal("Leozim" , findedPlayer.Name);
        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_not_add_a_Player_reason_no_CBF()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterTeams(champ.CurrentUser, TeamsMock());
//      <~~~~~~~~~~~~~~~~~~~~~~~[Add Player to Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamId = champ.GetTeamIdByName("Flasco");

            champ.RegisterUser("Léo");

            var tryAdd = champ.AddPlayer(champ.CurrentUser, new Player("Leozim"), teamId);

            var findedTeam = champ.GetTeamById(teamId);
            
            Assert.Equal(16, findedTeam.Players.Count);
            Assert.False(tryAdd);
        }

//      <~~~~~~~~~~~~~~~~~~~~~~~[Mockings]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
        public List<Team> TeamsMock()
        {
            foreach (var team in TeamsList)
            {
                team.AddPlayersList(PlayersList);
            } 
            return TeamsList;
        }
        public List<Match> MatchesMock()
        {
            var matchesList = new List<Match>{};

            foreach (var team in TeamsList)
            {
                team.AddPlayersList(PlayersList);
            }
//          <~~~~~~~~~~~~~~~~{Creating Possible Matches}~~~~~~~~~~~~~~~~>
            for (int i = 0; i < TeamsList.Count; i++)
            { 
                for (int j = 0 +i; j < TeamsList.Count; j++)
                {
                    if(i != j)
                    {
                        matchesList.Add(new Match(TeamsList[i], TeamsList[j]) );
                    } 
                }
            }

            return matchesList;
            
        }
        public List<Team> TeamsList {get; set;} = new List<Team>{    
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

    }
}