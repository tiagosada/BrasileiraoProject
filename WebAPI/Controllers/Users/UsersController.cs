using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Users;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly UserService _usersService;
        public UsersController()
        {
            _usersService = new UserService();
        }
        [HttpPost]
        public IActionResult Create(CreateUserRequest request)
        {
            if (request.Profile == Profile.CBF && request.Password != "admin123")
            {
                return Unauthorized();
            }

            var userId = _usersService.Create(request.Name, request.Profile);

            if (userId == Guid.Empty)
            {
               return BadRequest("Invalid Inputs");
            }
        
            return NoContent();
        }
        [HttpGet("{userID}")]
        public User GetUser(Guid userId)
        {
            return _usersService.GetUser(userId);
        }
    }
}