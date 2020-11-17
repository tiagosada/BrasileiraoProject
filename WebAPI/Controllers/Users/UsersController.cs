using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;

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
        [Route("signup")]
        public IActionResult SingUp(CreateUserRequest request)
        {
            var cur = new CreateUserRequest();
            if (!cur.ValidatePassword(request.Password).isValid)
            {
                return BadRequest(cur.ValidatePassword(request.Password).errors);
            }
            if (request.Profile == Profile.CBF && request.RolePassword != "admin123")
            {
                return Unauthorized("Senha de Cargo Invalida");
            }
            var password = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(request.Password));
            var response = _usersService.Create(request.Name, password, request.Profile);

            if (!response.isValid)
            {
               return BadRequest(response.Errors);
            }
            
            return Ok("User Created!");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUserRequest request)
        {
            //Encriptando a senha do login pra comparar com senha encripitada armazenada
            var password = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(request.Password));
            // Recupera o usuário
            var foundUser = _usersService.FindUser(request.Name);
            if (foundUser == null)
            {
                return BadRequest("Usuário ou senha inválidos");
            }
            if (!(foundUser.Password == password))
            {
                return BadRequest("Usuário ou senha inválidos");
            }
                     
            // Retorna os dados
            var token = TokenService.GenerateToken(foundUser.Name, foundUser.Profile.ToString());
            return Ok($"Bem vindo {foundUser.Name} /n {token} ");
        }
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("supporter")]
        [Authorize(Roles = "Supporter, CBF")]
        public string Employee() => "Torcedor";

        [HttpGet]
        [Route("CBF")]
        [Authorize(Roles = "CBF")]
        public string Manager() => "CBF";
    }
}