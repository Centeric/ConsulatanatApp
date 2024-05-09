using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.CommonHelper.JwtService
{
    public interface IJwtParams
    {
        string GetJwtKey();
    }
    public class JwtParam : IJwtParams
    {
        private static readonly string key = "ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM";

        public string GetJwtKey()
        {
            return key;
        }
    }
    
    
}
