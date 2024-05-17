using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.Models
{
    public class Users
    {
      
            public int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
            public string? Password { get; set; } // Change from "Password" to "HashedPassword"
            public int EmailConfirmed { get; set; }
            public string? CreatedTime { get; set; }
    }
 }

