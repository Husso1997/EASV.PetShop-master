using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Core.Entities
{
    public class CreateUserInputModel
    {
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
    }
}
