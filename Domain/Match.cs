using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Teams;

namespace Domain
{
    public class Match : Entity
    {
        public Team HomeTeam { get; private set; }
        public Team VisitingTeam { get; private set; }
        public int? HomeTeamGoals { get; private set; }
        public int? VisitingTeamGoals { get; private set; }
        

        public Match(Team team1, Team team2)
        {
           this.HomeTeam = team1;
           this.VisitingTeam = team2;

        }
        public void PlayMatch( List<string> HplayerNames, List<string> VplayerNames)
        {
            HomeTeamGoals = 0; VisitingTeamGoals = 0; 

            foreach (var name in HplayerNames)
            {
                var HomePlayer = HomeTeam.GetPlayerById(HomeTeam.GetPlayerIdByName(name) );
                HomePlayer.GiveGoal();
                ScoreGoalHomeTeam();
            }

             
            
            foreach (var name in VplayerNames)
            {
                var VisitingPlayer = VisitingTeam.GetPlayerById(VisitingTeam.GetPlayerIdByName(name) );
                VisitingPlayer.GiveGoal();
                ScoreGoalVisitingTeam();
            }

            if (HomeTeamGoals > VisitingTeamGoals)
            {
                HomeTeam.ScoreWin();
                VisitingTeam.ScoreDefeat();
            }
            else if (HomeTeamGoals < VisitingTeamGoals)
            {
                VisitingTeam.ScoreWin();
                HomeTeam.ScoreDefeat();
            }
            else
            {
                VisitingTeam.ScoreDraw();
                HomeTeam.ScoreDraw();
            }
        }
        public void PlayMatch()
        {
            HomeTeamGoals = 0; VisitingTeamGoals = 0;
            VisitingTeam.ScoreDraw();
            HomeTeam.ScoreDraw();
            
        }
        
        public void ScoreGoalHomeTeam()
        {
            HomeTeamGoals++;
            HomeTeam.ScoreMakedGoals();
            VisitingTeam.ScoreConcededGoals();
        }

        public void ScoreGoalVisitingTeam()
        {
            VisitingTeamGoals++;
            VisitingTeam.ScoreMakedGoals();
            HomeTeam.ScoreConcededGoals();
        }
    }
}

