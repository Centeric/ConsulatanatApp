using LawyerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.IServices
{
    public interface IConsultantService
    {
        Task<bool> Create(Consultant consultant);

        ////Task<IEnumerable<Consultant>> GetAll();

        Task<Consultant> GetConsultantById(string consultationId);

        Task<bool> UpdateConsultation(Consultant consultant);

        Task<bool> DeleteById(int id);
    }
}
