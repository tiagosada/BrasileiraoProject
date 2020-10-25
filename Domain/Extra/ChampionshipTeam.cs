using System;

namespace Domain
{
    public sealed class ChampionshipTeam : Team
    {
        public ChampionshipTeam(string nomeTime) : base(nomeTime)
        {
            Table = new ChampionshipTeamStatistics();
        }
    }
}