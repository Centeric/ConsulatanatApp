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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IConsultantRepository Consultants { get; }
        public INextStepsRepository NextSteps { get; }
        public IAuthRepository Users { get; }
        public ICommunicationUpdateRepository CommunicationUpdates { get; }
       

        public UnitOfWork(ApplicationDbContext context, IConsultantRepository consultant, IAuthRepository auth, INextStepsRepository nextSteps, ICommunicationUpdateRepository communicationUpdate)
        {
            _context = context;
            Consultants = consultant; 
            Users = auth;
            NextSteps = nextSteps;
            CommunicationUpdates = communicationUpdate;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

     
    }
}
