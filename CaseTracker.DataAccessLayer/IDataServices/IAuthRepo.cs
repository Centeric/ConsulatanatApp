using CaseTracker.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.IDataServices
{
    public interface IAuthRepo
    {
        Task<int> Add(Users user);
        Task<int> Delete(Users user);
      
        Task<Users> Get(int userId);
        Task<IEnumerable<Users>> GetAll();
        Task<Users?> GetByUsername(string email);
    }
}
