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
        public IAuthRepository Users { get; }
       

        public UnitOfWork(ApplicationDbContext context, IConsultantRepository consultant, IAuthRepository auth)
        {
            _context = context;
            Consultants = consultant; 
            Users = auth;
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
