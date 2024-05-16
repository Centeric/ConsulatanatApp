using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.IDataServices;
using CaseTracker.DataAccessLayer.Models;
using CaseTracker.DataAccessLayer.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.DataServices
{
    public class ConsultantRepo : IConsultantRepo
    {
        private readonly ApplicationDbContext _dbContext;
        public ConsultantRepo(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<int> Add(Consultant consultant)
        {
            _ = await _dbContext.Consultants.AddAsync(consultant);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<Consultant?> GetById(int id)
        {
            return await _dbContext
                .Consultants
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Delete(Consultant consultant)
        {
            _dbContext.Entry(consultant).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<Consultant?> GetById(string consultationId)
        {
            return await _dbContext
                .Consultants
               .Include(c => c.NextSteps)
               .Include(c => c.CommunicationUpdates)
               .Include(c=> c.AttachmentModels)
                .Where(x => x.ConsultationId == consultationId)
                .FirstOrDefaultAsync();
        }
        public async Task<List<Consultant>> GetAll()
        {
            return await _dbContext
                .Consultants
               
                .Where(x => x.ConsultationId != null)
                .ToListAsync();
        }

    }
}
