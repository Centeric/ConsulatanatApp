using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.Common
{
    public static class HashPasswordService
    {
       
            public static string HashPassword(string password)
            {
                var passwordHasher = new PasswordHasher<string>();
                return passwordHasher.HashPassword(null!, password);
            }

            public static bool VerifyHashedPassword(string hashedPassword, string providedPassword)
            {
                var passwordHasher = new PasswordHasher<string>();
                PasswordVerificationResult
                    result = passwordHasher.VerifyHashedPassword(null!, hashedPassword, providedPassword);
                return result == PasswordVerificationResult.Success;
            }
        
    }
}
