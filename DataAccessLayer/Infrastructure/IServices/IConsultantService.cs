using LawyerApp.Models.Model;
using LawyerApp.Models.ViewModel;
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
       Task<bool> CreateNextSteps(NextStepView next);
        Task<bool> CreateCommunicationUpdate(CommunicationUpdateView inp);

        ////Task<IEnumerable<Consultant>> GetAll();

        Task<ConsultantView> GetConsultantById(string consultationId);

        Task<bool> UpdateConsultation(Consultant consultant);

        Task<bool> DeleteById(int id);
        Task<IEnumerable<ConsultantView>> GetAllConsultant();
    }
}
