using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.IDataServices;
using CaseTracker.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.DataServices
{
    public class UserRepo : Repository<Users>, IUserRepo
    {

        public UserRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
