using DataAccessLayer;
using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

    }
}
