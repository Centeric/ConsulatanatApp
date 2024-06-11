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
        public async Task<Consultant> Add(Consultant consultant)
        {
             await _dbContext.Consultants.AddAsync(consultant);

             await _dbContext.SaveChangesAsync();
           
            return  consultant;
        }
        public async Task<Consultant?> GetById(int id)
        {
            return await _dbContext
                .Consultants
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
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
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
        public async Task<List<Consultant>> GetAllConsultantForDashboard()
        {
           // var currentDate = DateTime.Now;
           // var startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            return await _dbContext
                .Consultants

                .Where(x => x.ConsultationId != null)

                .OrderByDescending(x => x.CreatedDate)
                .Take(10)
                .ToListAsync();
        }
        public async Task<List<Consultant>> GetAllConsultantForUpcoming()
        {
            var validStatuses = new[] { "Pending", "On-Going", "Awaiting Return Of Documents" };
            return await _dbContext
                .Consultants

                .Where(x => x.ConsultationId != null && validStatuses.Contains(x.ProcessStatus))
                .OrderBy(x => x.DeadlineForDocumentSubmission)
                .Take(10)
                .ToListAsync();
        }
        public async Task<List<ConsultantStatusCount>> GetAllConsultantForStatus()
        {
            return await _dbContext
                .Consultants
                .Where(x => x.ConsultationId != null)
                .GroupBy(x => x.ProcessStatus)
                .Select(g => new ConsultantStatusCount
                {
                    ProcessStatus = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

        
        }
        public async Task<Consultant?> FindByConsultationId(string consultationId)
        {
            return await _dbContext.Consultants
           .Where(c => c.ConsultationId == consultationId)
           .FirstOrDefaultAsync();
        }
   

    }
}
