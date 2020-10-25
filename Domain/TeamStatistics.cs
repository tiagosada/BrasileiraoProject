using System;

namespace Domain
{
    public class TeamStatistics 
    {
        public int Score { get; private set;}
        public int PlayedMatchs { get; private set;} 
        public int Wins { get; private set; } 
        public int Defeats { get; private set; }   
        public int Draws { get; private set;} 
        public int MakedGoals { get; private set;}
        public int ConcededGoals { get; private set;} 
        public int GoalsDifference { get; private set;} 
        public double Rate { get; private set;} = 0.0;

      
       
        
        public void PlayMatch()
        {
            PlayedMatchs++;
            UpdateRate();
        }     
        public void ScoreWin()
        {
            Wins++;
            Score+=3;
            PlayMatch();    
        }
       
        public void ScoreDefeat()
        {
            Defeats++;
            PlayMatch();
        }

        public void ScoreDraw()
        {
            Draws++;
            Score++;
            PlayMatch();
        }

        public void ScoreConcededGoals()
        {
            ConcededGoals++;
            UpdateGoalDifference();
        }

        public void ScoreMakedGoals()
        {
            MakedGoals++;
            UpdateGoalDifference();
        }
        public void UpdateGoalDifference()
        {
            GoalsDifference = MakedGoals - ConcededGoals;
        }
        

        public void UpdateRate()
        {
            Rate = (Score/(PlayedMatchs * 3.0))*100.0;
        }
        
        public override string ToString()
        {
            return $"{Score} | {PlayedMatchs} | {Wins} | {Draws} | {Defeats} | {MakedGoals} | {ConcededGoals} | {Math.Round(Rate, 2)}%";
        }
    }
}    