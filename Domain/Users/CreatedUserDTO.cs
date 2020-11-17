using System;
using System.Collections.Generic;

namespace Domain.Users
{
    public class CreatedUserDTO
    {
        public Guid Id { get; set; }
        public IList<string> Errors { get; set; }
        public bool isValid { get; set; }
        public CreatedUserDTO()
        {
            isValid = true;
        }
        public CreatedUserDTO(IList<string> errors)
        {
            Errors = errors;
        }
    }
}