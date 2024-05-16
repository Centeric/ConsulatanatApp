using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.JwtTokenHandler
{
    public class JwtParams:IJwtParams
    {
        private static readonly string key = "ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM";

        public string GetJwtKey()
        {
            return key;
        }

    }
    public interface IJwtParams
    {
        string GetJwtKey();
    }
}
