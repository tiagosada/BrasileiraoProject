using System;
using System.Collections.Generic;
using Domain.People;
using Domain.Teams;

namespace Domain.Players
{
    public class Player : Person
    {
        public virtual Team Team { get; private set; }
        public Guid TeamId { get; private set; }
        public int Goals { get; set; }
        //public string Position { get; set; }

        public Player(Guid teamId, string name) : base (name)
        {
            TeamId = teamId;
        }
        public void GiveGoal()
        {
            this.Goals++;
        }
        public (List<string> errors, bool isValid) Validate()
        {
            var errs = new List<string>(); 
            
            if (!ValidateName())
            {
                errs.Add("Invalid name");
            }

            return (errs, errs.Count == 0);
        }
    }
}