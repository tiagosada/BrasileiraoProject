using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Users;

namespace Domain.Players
{
    public class PlayersService
    {
        public CreatedPlayerDTO Create(string name)
        {
            var player = new Player(name);
            var playerVal = player.Validate();

            if (!playerVal.isValid)
            {
                return new CreatedPlayerDTO(playerVal.errors);
            }
            
            PlayersRepository.Add(player);
            return new CreatedPlayerDTO(player.Id);
        }

        public List<Guid> GetAll()
        {
            return (from p in PlayersRepository.Players select p.Id).ToList();
        }
        // public User GetBYId()
        // {
        //     return (from p in PlayersRepository.Players select p.Id).ToList();
        // }
    }
}