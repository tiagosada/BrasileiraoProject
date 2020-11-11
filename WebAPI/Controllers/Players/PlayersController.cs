  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Players;
using Domain.Users;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        public readonly PlayersService _playersService;
        public readonly UserService _usersService;
        public PlayersController()
        {
            _playersService = new PlayersService();
            _usersService = new UserService();
        }
        
        [HttpPost]
        public IActionResult CreatePlayer(CreatePlayerRequest request)
        {
            StringValues _userId;
            var headers= Request.Headers;
            if(!headers.TryGetValue("UserId", out _userId))
            {
                return Unauthorized();
            }    

            var user = _usersService.GetUser(Guid.Parse(_userId));

            if (user == null)
            {
                return Unauthorized();
            }

            if (user.Profile == Profile.Supporter)
            {
                // return Forbid(); //notWorking!
                return StatusCode(403, "User not CBF!");

            }

            var response = _playersService.Create(request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Id);
        }

        [HttpGet]
        public List<Guid> Get()
        {
            return _playersService.GetAll();
        }
    }
}