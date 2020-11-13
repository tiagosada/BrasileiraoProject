using System;
using System.Collections.Generic;
using Domain.People;

namespace Domain
{
    public class Player : Person
    {

        public int Goals { get; set; }
        //public string Position { get; set; }

        public Player(string name) : base (name)
        {
            Id = Guid.NewGuid();
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