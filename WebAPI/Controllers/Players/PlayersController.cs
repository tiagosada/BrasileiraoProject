  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Players;
using Domain.Users;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        public readonly PlayersService _playersService;
        public PlayersController()
        {
            _playersService = new PlayersService();
        }
        
        [HttpPost]
        public IActionResult Post(CreatePlayerRequest request)
        {
            if (request.User.Profile != Profile.CBF)
            {
                return Forbid("User is not CBF");
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