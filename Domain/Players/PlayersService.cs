using System;

namespace Domain.Players
{
    public class PlayersService
    {
        private readonly PlayersRepository _playersRepository = new PlayersRepository();
        public CreatedPlayerDTO Create(Guid teamId, string name)
        {
            var player = new Player(teamId, name);
            var playerValidation = player.Validate();

            if (playerValidation.isValid)
            {
                _playersRepository.Add(player);
                return new CreatedPlayerDTO(player.Id);
            }

            return new CreatedPlayerDTO(playerValidation.errors);
        }

        public bool Remove(Guid id)
        {
            var foundPlayer = _playersRepository.Get(player => player.Id == id);
            _playersRepository.Remove(foundPlayer);
            return true;
        }
    }
}