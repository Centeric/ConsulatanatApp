using LawyerApp.CommonHelper.CustomGeneric;
using LawyerApp.Models.Model;
using LawyerApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.IServices
{
    public interface IAuthRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
