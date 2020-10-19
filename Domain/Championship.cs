using System;
using System.Collections.Generic;

namespace Domain
{
    public class Championship
    {
        private  List<User> _users {get; set;}
        public IReadOnlyCollection<User> User => _users;
        public Championship()
        {
            var _users = new List<User>();
        }
        public bool CreateUsers(List<User> User, string password)
        {
            if(password != "cbffoda" || User == null)
            {
                return false;
            }

            _users = User;
            return true;
        }

    }
}