using DataAccessLayer;
using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
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
