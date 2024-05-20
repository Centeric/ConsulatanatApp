using CaseTracker.DataAccessLayer.Models;
using CaseTracker.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.Request
{
    public class CreateUserRequest
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
            
        public string? Password { get; set; }
      

        public Users ToUsers()
        {
            return new Users
            {
                Username = Username,
                Email = Email,
                Password = Password,
                HashPassword = HashPasswordService.HashPassword(Password!),
                CreatedTime =DateTime.Now
            };
        }
    }
}
