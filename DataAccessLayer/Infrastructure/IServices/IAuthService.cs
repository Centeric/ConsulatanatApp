using LawyerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.IServices
{
    public interface IAuthService
    {
        Task<bool> Add(User user);
        Task<bool> Login(string email, string password);
    }
}
