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
    public class ConsultantRepository : Repository<Consultant>, IConsultantRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsultantRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async  Task<Consultant> GetByConsultationId(string consultationId)
        {
            var data= await _context.Consultants
        .Include(c => c.NextSteps)
        .Include(c => c.CommunicationUpdates)
         .FirstOrDefaultAsync(c => c.ConsultationId == consultationId);
            return data;
        }
    }
}
