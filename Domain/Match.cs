using System;

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
        public void PlayMatch()
        {
            var rand = new Random();
            var HomeGoals = rand.Next(4);
            var VisitingGoals = rand.Next(4);

            ScoreGoalsHomeTeam(HomeGoals);
            ScoreGoalsVisitingTeam(VisitingGoals);

            if (HomeGoals > VisitingGoals)
            {
                HomeTeam.Table.ScoreWin();
                VisitingTeam.Table.ScoreDefeat();
            }
            else if (HomeGoals < VisitingGoals)
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
        public void PlayMatch(int homeGoals, int visitingGoals)
        {   
            ScoreGoalsHomeTeam(homeGoals);
            ScoreGoalsVisitingTeam(visitingGoals);

            if (homeGoals > visitingGoals)
            {
                HomeTeam.Table.ScoreWin();
                VisitingTeam.Table.ScoreDefeat();
            }
            else if (homeGoals < visitingGoals)
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
        public void ScoreGoalsHomeTeam(int goal)
        {
            HomeTeamGoals = goal;
            for (int i = 0; i < goal; i++)
            {
                HomeTeam.ScoreAGoal();
                VisitingTeam.Table.ScoreConcededGoals();
            }
        }

        public void ScoreGoalsVisitingTeam(int goal)
        {
            VisitingTeamGoals = goal;
            for (int i = 0; i < goal; i++)
            {
                VisitingTeam.ScoreAGoal();
                HomeTeam.Table.ScoreConcededGoals();
            }
        }
    }
}

