using Xunit;
using Domain;
using System.Collections.Generic;
using System.Linq;

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
            var teamsmock = TeamsMock();
            var tryRegist = champ.RegisterTeams(teamsmock);

            Assert.False(champ.championshipStart);
            Assert.Equal(teamsmock.Count, champ.Teams.Count);
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

            var tryRegist = champ.RegisterTeams(TeamsMock());

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

            var tryRegist = champ.RegisterTeams(TeamsMock());

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
            var teamsmock = TeamsMock();
            champ.RegisterTeams(teamsmock);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Add Player to Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamId = champ.GetTeamIdByName("Flasco");

            var tryAdd =champ.AddPlayer(new Player("Leozim"), teamId);

            var foundTeam = champ.GetTeamById(teamId);
            var foundPlayer = foundTeam.GetPlayerById(foundTeam.GetPlayerIdByName("Leozim"));
            
            Assert.True(tryAdd);
            Assert.Equal(17, foundTeam.Players.Count);
            Assert.Equal("Leozim" , foundPlayer.Name);
        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_not_add_a_Player_reason_no_CBF()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterTeams(TeamsMock());
//      <~~~~~~~~~~~~~~~~~~~~~~~[Add Player to Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamId = champ.GetTeamIdByName("Flasco");
            var foundTeam = champ.GetTeamById(teamId);
            champ.RegisterUser("Godofredo");

            var tryAdd = champ.AddPlayer(new Player("Leozim"), teamId);
            
            Assert.False(tryAdd);
            Assert.Equal(16, foundTeam.Players.Count);
        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_remove_a_Player()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamsmock = TeamsMock();
            champ.RegisterTeams(teamsmock);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Remove Player of Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamId = champ.GetTeamIdByName("Flasco");

            var foundTeam = champ.GetTeamById(teamId);
            var foundPlayer = foundTeam.GetPlayerById(foundTeam.GetPlayerIdByName("Iago"));
            

            var tryRemove = champ.RemovePlayer(foundPlayer, teamId);
            
            Assert.True(tryRemove);
            Assert.Equal(15, foundTeam.Players.Count);
            Assert.DoesNotContain(foundPlayer , foundTeam.Players);
        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_not_remove_a_Player_reason_not_CBF()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamsmock = TeamsMock();
            champ.RegisterTeams(teamsmock);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Remove Player of Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamId = champ.GetTeamIdByName("Flasco");

            var foundTeam = champ.GetTeamById(teamId);
            var foundPlayer = foundTeam.GetPlayerById(foundTeam.GetPlayerIdByName("Tiago"));
            
            champ.RegisterUser("Leandro");

            var tryRemove = champ.RemovePlayer(foundPlayer, teamId);
            
            Assert.False(tryRemove);
            Assert.Equal(16, foundTeam.Players.Count);
            Assert.Contains(foundPlayer , foundTeam.Players);
        }

//      <-----------------------------------[Matches Test]------------------------------------------------> 
        [Fact]
        public void Should_Register_Teams_on_Championship_and_Create_Matches()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();

//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");            
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamsmock = TeamsMock();
            champ.RegisterTeams(teamsmock);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Matches]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>           
            var tryCMat = champ.CreateMatches();

            Assert.True(tryCMat);
            Assert.NotEmpty(champ.Matches);
            Assert.Equal(45, champ.Matches.Count);

        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_not_Create_Matches_reason_not_CBF()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();

//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");            
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamsmock = TeamsMock();
            champ.RegisterTeams(teamsmock);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Matches]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>  
            champ.RegisterUser("Leandro");

            var tryCMat = champ.CreateMatches();

            Assert.False(tryCMat);
            Assert.Empty(champ.Matches);

        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_not_Create_Matches_reason_not_enough_teams()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();

//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");            
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamsmock = TeamsMock(7);
            champ.RegisterTeams(teamsmock);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Matches]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>           
            var tryCMat = champ.CreateMatches();

            Assert.False(tryCMat);
            Assert.Empty(champ.Matches);

        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_Create_Matches_then_GenerateRound()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();

//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");            
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamsmock = TeamsMock();
            champ.RegisterTeams(teamsmock);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Matches]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>           
            var tryCMat = champ.CreateMatches();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Generate Round]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>           

            var tryGenerateRound = champ.RoundGenerator();

            Assert.True(tryGenerateRound);
            Assert.NotEmpty(champ.Rounds);
            Assert.Equal(1, champ.Round);
            Assert.Equal(40, champ.Matches.Count);
        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_Create_Matches_then_not_GenerateRound_reason_not_CBF()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();

//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");            
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamsmock = TeamsMock();
            champ.RegisterTeams(teamsmock);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Matches]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>           
            var tryCMat = champ.CreateMatches();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Generate Round]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>           
            champ.RegisterUser("Ruan");
            var tryGenerateRound = champ.RoundGenerator();

            Assert.False(tryGenerateRound);
            Assert.Empty(champ.Rounds);
            Assert.Equal(45, champ.Matches.Count);
        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_Create_Matches_then_not_GenerateRound_reason_not_enough_teams()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();

//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");            
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamsmock = TeamsMock(7);
            champ.RegisterTeams(teamsmock);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Matches]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>           
            var tryCMat = champ.CreateMatches();
//      <~~~~~~~~~~~~~~~~~~~~~~~[Generate Round]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var tryGenerateRound = champ.RoundGenerator();

            Assert.False(tryGenerateRound);
            Assert.Empty(champ.Rounds);
        }
        [Fact]
        public void Should_Register_Teams_on_Championship_and_Create_Matches_then_not_GenerateRound_reason_not_enough_matches()
        {
//      <~~~~~~~~~~~~~~~~~~~~~~~[Creating Championship]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var champ = new Championship();

//      <~~~~~~~~~~~~~~~~~~~~~~~[Register User]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

            champ.RegisterUser("Tiago", "Pa$Sw0rD");            
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Teams]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var teamsmock = TeamsMock();
            champ.RegisterTeams(teamsmock);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Register Matches]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>           
            var tryCMat = champ.CreateMatches();
            champ.Matches.Remove(champ.Matches[0]);
//      <~~~~~~~~~~~~~~~~~~~~~~~[Generate Round]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>
            var tryGenerateRound = champ.RoundGenerator();

            Assert.False(tryGenerateRound);
            Assert.Empty(champ.Rounds);
        }
        
//      <~~~~~~~~~~~~~~~~~~~~~~~[Mockings]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

        public List<Team> TeamsMock(int amount)
        {
            for(int i = 0; i < TeamsList.Count; i++)
            {
                TeamsList[i].AddPlayersList(PlayersList[i]);
            }
            return TeamsList.Take(amount).ToList();
        }
        public List<Team> TeamsMock()
        {
            for(int i = 0; i < TeamsList.Count; i++)
            {
                TeamsList[i].AddPlayersList(PlayersList[i]);
            } 
            return TeamsList;
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

        public List<List<Player>> PlayersList { get; set; } = new List<List<Player>>
        {
            new List<Player>
            {
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
            },
            new List<Player>
            {
                new Player("Azul"),
                new Player("Ateu"),
                new Player("Abalado"),
                new Player("Atunir"),
                new Player("Aldair"),
                new Player("Atum"),
                new Player("Alcemar"),
                new Player("Alcides"),
                new Player("Alceu"),
                new Player("Alcione"),
                new Player("Among"),
                new Player("Ajuju"),
                new Player("Ajudante"),
                new Player("Aberração"),
                new Player("Arbitro"),
                new Player("Ambito"),
            },
            new List<Player>
            {
                new Player("Bebe"),
                new Player("Bernardo"),
                new Player("Batman"),
                new Player("Baiano"),
                new Player("Bolacha"),
                new Player("Biscoito"),
                new Player("Bola"),
                new Player("Bituca"),
                new Player("Benjamim"),
                new Player("Bartolomeu"),
                new Player("Bento"),
                new Player("Bolsonaro"),
                new Player("Bemdez"),
                new Player("Bobo"),
                new Player("Babaca"),
                new Player("Bozo"),    
            },
            new List<Player>
            {
                new Player("Carlos"),
                new Player("Chico"),
                new Player("Cabelo"),
                new Player("Cabeludo"),
                new Player("Coca"),
                new Player("Cacau"),
                new Player("Colombo"),
                new Player("Cracudo"),
                new Player("Cebola"),
                new Player("Cicero"),
                new Player("Cabeça"),
                new Player("Cazuza"),
                new Player("Cozido"),
                new Player("Cazinha"),
                new Player("Caco"),
                new Player("CD"),
            },
            new List<Player>
                {
                new Player("Duda"),
                new Player("Dondoca"),
                new Player("Dafne"),
                new Player("Dagmar"),
                new Player("Dagoberto"),
                new Player("Daisy"),
                new Player("Dalbert"),
                new Player("Dália"),
                new Player("Dalila"),
                new Player("Dalmiro"),
                new Player("Dalton"),
                new Player("Dalva"),
                new Player("Damarina"),
                new Player("Damasceno"),
                new Player("Damiana"),
                new Player("Damião"),
            },
            new List<Player>
            {
                new Player("Edberto"),
                new Player("Edgar"),
                new Player("Edite"),
                new Player("Edmar"),
                new Player("Edmundo"),
                new Player("Eduardo"),
                new Player("Edvaldo"),
                new Player("Elaine"),
                new Player("Elba"),
                new Player("Eleazar"),
                new Player("Ecléia"),
                new Player("Edelmar"),
                new Player("Edigenio"),
                new Player("Edvige"),
                new Player("Efraim"),
                new Player("Elaine"),
            },
            new List<Player>
            {
                new Player("Fábio"),
                new Player("Fauzi"),
                new Player("Federico"),
                new Player("Felicio"),
                new Player("Feliciano"),
                new Player("Felisbela"),
                new Player("Felisberto"),
                new Player("Félix"),
                new Player("Ferdinando"),
                new Player("Fernandes"),
                new Player("Fidelino"),
                new Player("Filadelfo"),
                new Player("Felipe"),
                new Player("Fileas"),
                new Player("Filomeno"),
                new Player("Filemom"),
            },
            new List<Player>
            {
                new Player("Gabriel"),
                new Player("George"),
                new Player("Gerson"),
                new Player("Gideão"),
                new Player("Gildo"),
                new Player("Gonçalo"),
                new Player("Guilherme"),
                new Player("Gaspar"),
                new Player("Geraldino"),
                new Player("Gervásio"),
                new Player("Gil"),
                new Player("Godofredo"),
                new Player("Gregório"),
                new Player("Gustavo"),
                new Player("Gastão"),
                new Player("Golias"),
            },
            new List<Player>
            {
                new Player("Helberto"),
                new Player("Henrique"),
                new Player("Hamílcar"),
                new Player("Hamilton"),
                new Player("Haníbal"),
                new Player("Harry"),
                new Player("Hassan"),
                new Player("Heriberto"),
                new Player("Habib"),
                new Player("Haidê"),
                new Player("Haroldo"),
                new Player("Hazael"),
                new Player("Heitor"),
                new Player("Hebe"),
                new Player("Heladio"),
                new Player("Helcio"),
            },
            new List<Player>
            {
                new Player("Wesley"),
                new Player("Wellington"),
                new Player("William"),
                new Player("Wendel"),
                new Player("Wagner"),
                new Player("Wanderson"),
                new Player("Wilson"),
                new Player("Wallace"),
                new Player("Washington"),
                new Player("Winderson"),
                new Player("Wanderley"),
                new Player("Weverton"),
                new Player("Wilton"),
                new Player("Welton"),
                new Player("Wilmar"),
                new Player("Waldir"),
            }
        };
    }
}