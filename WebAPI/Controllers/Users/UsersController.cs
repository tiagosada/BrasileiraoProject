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
        [HttpPost]
        public Guid Post(CreateUserRequest request)
        {
           var user = new User(name);
           return user.Id;
        }
    }
}
