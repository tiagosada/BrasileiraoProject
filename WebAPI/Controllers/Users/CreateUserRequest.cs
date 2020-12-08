using System.Collections.Generic;
using System.Linq;
using Domain.Users;

namespace WebAPI.Controllers.Users
{
    public class CreateUserRequest : LoginUserRequest
    {
        public Profile Profile { get; set; }
        public string RolePassword { get; set; }
        public string Email { get; set; }
        public (List<string> errors,bool isValid) ValidatePassword(string password)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(password))
            {
                errors.Add("Insira uma senha");
            }
            if (password.Length < 5)
            {
                errors.Add("A senha deve ter no mínimo 5 dígitos");
            }
            if (password.Any(x => !char.IsLetterOrDigit(x)))
            {
                errors.Add("A senha deve ter apenas Números e Letras (Não deve conter acentos ou simbolos nem 'ç')");
            }
            
            return (errors, errors.Count == 0);
        }
    }
}