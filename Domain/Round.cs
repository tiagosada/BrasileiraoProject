using System;
using System.Collections.Generic;

namespace Domain
{
    public class Round
    {
        public List<Match> Matches { get; private set; }
        public bool PlayedRound {get; set; } = false;
        

        public Round(List<Match> matches)
        {
            Matches = matches;
        }
    }
}