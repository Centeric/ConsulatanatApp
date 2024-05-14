using DataAccessLayer;
using LawyerApp.DataAccessLayer.Infrastructure.Services;
using LawyerApp.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.CommonHelper.CustomGeneric
{
    public class GenericClass<T> :Repository<T>, IGenericClass<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericClass(ApplicationDbContext dbContext) : base(dbContext)
        { 
            _dbContext = dbContext;
        }
        public async Task<Consultant> GetByConsultationId(string consultationId)
        {
            return await _dbContext.Set<Consultant>().FirstOrDefaultAsync(c => c.ConsultationId == consultationId);
        }
        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
