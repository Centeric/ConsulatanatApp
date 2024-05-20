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
           return  await _dbContext.SaveChangesAsync();
            
        }
        public async Task<Consultant?> GetById(int id)
        {
            return await _dbContext
                .Consultants
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<NextSteps?> GetByNextStepId(int consultantId)
        {
            return await _dbContext
                .NextSteps
                .Where(x => x.NextStepId == consultantId)
                .FirstOrDefaultAsync();
        }
        public async Task<CommunicationUpdates?> GetByCommunicationId(int consultantId)
        {
            return await _dbContext
                .CommunicationUpdates
                .Where(x => x.CommunicationId == consultantId)
                .FirstOrDefaultAsync();
        }
        public async Task<AttachmentModel?> GetByAttachmentId(int consultantId)
        {
            return await _dbContext
                .AttachmentModels
                .Where(x => x.ConsultantId == consultantId)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Delete(Consultant consultant)
        {
            _dbContext.Entry(consultant).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteStep(NextSteps next)
        {
            _dbContext.Entry(next).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteCommunicatioUpdate(CommunicationUpdates communication)
        {
            _dbContext.Entry(communication).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteAttachments(AttachmentModel attachment)
        {
            _dbContext.Entry(attachment).State = EntityState.Modified;
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
