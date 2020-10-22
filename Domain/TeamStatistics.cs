using System;

namespace Domain
{
    public abstract class TeamStatistics 
    {
        public int Score { get; private set;}
        public int PlayedMatchs { get; private set;} 
        public int Wins { get; private set; } 
        private bool Win = false;  
        public int Defeats { get; private set; }   
        public int Draws { get; private set;} 
        private bool Draw = false;
        public int MakedGoals { get; private set;}
        public int ConcededGoals { get; private set;} 
        public double ExploitationRate { get; private set;} = 0.0;

      
       
        
        public void PlayMatch()
        {
            PlayedMatchs++;
        }     
       public void ScoreWin()
       {
            Wins++;
            Win = true;
            Draw = false;

       }
       
        public void ScoreDeafeat()
        {
            Defeats++;
        }

        public void ScoreDraw()
        {
            Draws++;
            Win = false;
            Draw = true;
        }

        public void ScoreConcededGoals()
        {
            ConcededGoals++;
        }

        public void ScoreMakedGoals()
        {
            MakedGoals++;
        }

        public void AtualizeExploitationRate()
        {
            ExploitationRate = (Score/(PlayedMatchs * 3.0))*100.0;
        }
        public void SetScore()
        {
            if (Win)
            {
                Score +=3;
            }
            else if (Draw)
            {
                Score +=1;
            }

        }
        
        public override string ToString()
        {
            return $"{Score} | {PlayedMatchs} | {Wins} | {Draws} | {Defeats} | {MakedGoals} | {ConcededGoals} | {Math.Round(ExploitationRate, 2)}%";
        }
    }
}    