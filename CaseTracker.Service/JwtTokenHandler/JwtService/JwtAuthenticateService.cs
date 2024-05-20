using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.JwtTokenHandler.JwtService
{
    public class JwtAuthenticateService : IJwtAuthenticateService
    {
        private static string token = "";
        private readonly IJwtParams _jwtParams;


        public JwtAuthenticateService(IJwtParams jwtParams)
        {
            _jwtParams = jwtParams;
        }

        public string GenerateToken(string email)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_jwtParams.GetJwtKey());

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Email, email),
               // new Claim(ClaimTypes.)
            }),

                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
            string? returnToken = tokenHandler.WriteToken(token);

            return returnToken;
        }
    }
}
