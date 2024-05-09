using LawyerApp.CommonHelper.JwtService;
using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using LawyerApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        public AuthService(IUnitOfWork unitOfWork,IJwtService jwtService )
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }
        public async Task<bool> Add(User user)
        {
            if (user != null)
            {
                await _unitOfWork.Users.Add(user);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<LoginView> Login(string email, string password)
        {
            var user = await _unitOfWork.Users.GetByEmail(email);
            if (user is null) 
                return null;
                    
      
            string jwtToken = _jwtService.GenerateToken(user.Email ?? "");

            LoginView response = new()
            {
               
                Email= user.Email,
                Password=user.Password,
                Token = jwtToken
            };

              return response;
         }
    }
}
