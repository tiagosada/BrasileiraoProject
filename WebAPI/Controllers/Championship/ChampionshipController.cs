using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain;
using Domain.Players;

namespace WebAPI.Controllers.Championship
{
    [ApiController]
    [Route("[controller]")]
    public class ChampionshipController : ControllerBase
    {
        [HttpPost]
        // public IActionResult Create(ChampCreateUserRequest request)
        // {
            // if (request.Profile == Profile.CBF && request.Password != "admin123")
            // {
            //     return Unauthorized();
            // }
            
            // var player = new Player(request.Name);

            // return Ok(player.Id);
        // }
    }
}