using CaseTracker.DataAccessLayer.Responses;
using CaseTracker.Service.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.DataLogics.IServices
{
    public interface IAuthService
    {
        Task<Result> Add(CreateUserRequest userRequest);
        Task<Result> Login(string email, string password);
        Task<Result> Delete(int userId);
    }
}
