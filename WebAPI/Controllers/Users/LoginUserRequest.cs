using Domain.Users;

namespace WebAPI.Controllers.Users
{
    public class LoginUserRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}