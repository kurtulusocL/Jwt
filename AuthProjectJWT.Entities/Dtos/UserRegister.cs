using AuthProjectJWT.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.Entities.Dtos
{
    public class UserRegister : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
