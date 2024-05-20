using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.IDataServices;
using CaseTracker.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.DataServices
{
    public class AuthRepo : IAuthRepo
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthRepo(ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public async Task<int> Add(Users user)
        {
            _dbContext.AuthUsers.Add(user);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Users user)
        {
            _dbContext.AuthUsers.Remove(user);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _dbContext.AuthUsers.ToListAsync();
        }

        public async Task<Users?> Get(int userId)
        {
            return await _dbContext.AuthUsers.FirstOrDefaultAsync(x => x.UserId == userId);
        }
        public Task<Users?> GetByUsername(string email)
        {
            return _dbContext.AuthUsers.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
