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

            var response = _usersService.Create(request.Name, request.Profile);

            if (!response.isValid)
            {
               return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }
        [HttpGet]
        public Guid GetUser()
        {
            var headers= Request.Headers;
            headers.TryGetValue("UserId", out var _userId);
            if (_usersService.ContainsUser(_userId))
            {
                return Guid.Parse(_userId);
            }
            return Guid.Empty;
        }
    }
}