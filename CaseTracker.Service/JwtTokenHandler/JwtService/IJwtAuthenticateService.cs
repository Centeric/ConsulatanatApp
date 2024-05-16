using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.JwtTokenHandler.JwtService
{
    public interface IJwtAuthenticateService
    {
        string GenerateToken(string email);
    }
}
