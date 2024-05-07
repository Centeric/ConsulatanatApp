using DataAccessLayer;
using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.Services
{
    public class ConsultantRepository : Repository<Consultant>, IConsultantRepository
    {
        public ConsultantRepository(ApplicationDbContext context) : base(context) { }
    }
}
