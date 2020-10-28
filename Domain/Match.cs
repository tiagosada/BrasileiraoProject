using System;
using System.Collections.Generic;

namespace Domain
{
    public class Match
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
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
                HomeTeam.Table.ScoreWin();
                VisitingTeam.Table.ScoreDefeat();
            }
            else if (HomeTeamGoals < VisitingTeamGoals)
            {
                VisitingTeam.Table.ScoreWin();
                HomeTeam.Table.ScoreDefeat();
            }
            else
            {
                VisitingTeam.Table.ScoreDraw();
                HomeTeam.Table.ScoreDraw();
            }
        }
        
        public void ScoreGoalHomeTeam()
        {
            HomeTeamGoals++;
            HomeTeam.Table.ScoreMakedGoals();
            VisitingTeam.Table.ScoreConcededGoals();
        }

        public void ScoreGoalVisitingTeam()
        {
            VisitingTeamGoals++;
            VisitingTeam.Table.ScoreMakedGoals();
            HomeTeam.Table.ScoreConcededGoals();
        }
    }
}

