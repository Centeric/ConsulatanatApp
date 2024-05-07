using DataAccessLayer;
using LawyerApp.DataAccessLayer.Infrastructure.IServices;
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

       

        public UnitOfWork(ApplicationDbContext context, IConsultantRepository consultant)
        {
            _context = context;
            Consultants = consultant;                            
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
