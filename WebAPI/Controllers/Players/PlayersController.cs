using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(CreatePlayerRequest request)
        {
            // if (request.Profile == Profile.CBF && request.Password != "admin123")
            // {
            //     return Unauthorized();
            // }
            
            var player = new Player(request.Name);

            return Ok(player.Id);
        }
    }
}