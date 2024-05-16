using CaseTracker.DataAccessLayer.Models;
using CaseTracker.DataAccessLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.IDataServices
{
    public interface IConsultantRepo
    {
        Task<int> Add(Consultant consultant);
        Task<Consultant?> GetById(int id);
        Task<int> Delete(Consultant consultant);
        Task<Consultant?> GetById(string consultationId);
        Task<List<Consultant>> GetAll();

    }
}
