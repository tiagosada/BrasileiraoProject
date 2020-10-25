using System;
using System.Collections.Generic;

namespace Domain
{
    public class PlayerScorer
    {
        public string playerScorer { get; set; }

        public PlayerScorer(string playerScorer)
        {
            this.playerScorer = playerScorer;
        }
    }
}