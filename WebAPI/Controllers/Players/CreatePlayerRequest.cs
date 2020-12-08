  
using Domain.Players;
using Domain.Users;

namespace WebAPI.Controllers.Players
{
    public class CreatePlayerRequest
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public User User {get; set; }
    }
}