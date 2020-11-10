using System;
using System.Collections.Generic;

namespace Domain.Players
{
    public class CreatedPlayerDTO
    {
        public Guid Id { get; set; }
        public List<string> Errors { get; set; }
        public bool IsValid { get; set; }
        
        public CreatedPlayerDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }
        public CreatedPlayerDTO(List<string> errors)
        {
            Errors = errors;
        }
    }
}