using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.JwtTokenHandler
{
    public class JwtParams:IJwtParams
    {
        private readonly IConfiguration _configuration;

        public JwtParams(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetJwtKey()
        {
            return _configuration["AuthKey:SecretKey"];
        }
    }
    public interface IJwtParams
    {
        string GetJwtKey();
    }
}
