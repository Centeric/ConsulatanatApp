using CaseTracker.DataAccessLayer.IDataServices;
using CaseTracker.DataAccessLayer.Models;
using CaseTracker.DataAccessLayer.Responses;
using CaseTracker.Service.Common;
using CaseTracker.Service.DataLogics.IServices;
using CaseTracker.Service.JwtTokenHandler.JwtService;
using CaseTracker.Service.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.DataLogics.Services
{
    public class AuthService: IAuthService
    {
        private readonly IJwtAuthenticateService _jwtAuthenticateService;
        private readonly IAuthRepo _authRepo;
        public AuthService(IAuthRepo authRepo, IJwtAuthenticateService jwtAuthenticateService) 
        { 
            _authRepo = authRepo;
            _jwtAuthenticateService = jwtAuthenticateService;
        }
        public async Task<Result> Add(CreateUserRequest userRequest)
        {
            try
            {
                Users user = userRequest.ToUsers();

                int response = await _authRepo.Add(user);
                return response != 0 ? Result.Success(Constants.Added,response) : Result.Failure(Constants.Error);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<Result> Login(string email, string password)
        {
            Users? user = await _authRepo.GetByUsername(email);
            if (user is null) return Result.Failure(Constants._User.EmailError);

            bool result = HashPasswordService.VerifyHashedPassword(user.HashPassword!, password);
            if (!result) return Result.Failure(Constants._User.PasswordError);
            string jwtToken = _jwtAuthenticateService.GenerateToken(user.Email ?? "");

            LoginResponse response = new()
            {
               
                UserId = user.UserId,
                Username = user.Username,
                Email =user.Email,
                
                Token = jwtToken
            };

            return Result.Success(Constants._User.LoggedIn, response);
        }
        public async Task<Result> Delete(int userId)
        {
            Users? response = await _authRepo.Get(userId);
            return response is null
                ? Result.Failure(Constants.IdNotFound)
                : await _authRepo.Delete(response) != 0
                    ? Result.Success(Constants.Deleted)
                    : Result.Failure(Constants.Error);
        }
    }
}
