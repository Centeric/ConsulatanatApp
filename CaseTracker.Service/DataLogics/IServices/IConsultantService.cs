using CaseTracker.DataAccessLayer.Responses;
using CaseTracker.Service.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.DataLogics.IServices
{
    public interface IConsultantService
    {
        Task<Result> Add(CreateConsultantRequest consultant);
        Task<Result> UpdateConsultant(UpdateConsultantRequest request);
        Task<Result> Delete(int id);
        Task<Result> GetById(string consultationId);
        Task<Result> CreateNextStep(CreateNextStepRequest request);
        Task<Result> CreateCommunicationUpdate(CreateCommunicationRequest request);
        Task<Result> GetConsultant();
        Task<Result> GetConsultantDashboard();
        Task<Result> GetUpcomingConsultant();
        Task<Dictionary<string, object>> GetConsultantByStatus();
        //  Task<Result> AddAttachment(List<CreateAttachmentRequest> requests);
        Task<Result> AddAttachment(CreateAttachmentDTO dto);
        Task<Result> DeleteNextStep(int NextStepId);
        Task<Result> DeleteCommunication(int CommunicationId);
        Task<Result> DeleteAttachment(int AttachmentId);
        Task<Result> UpdateStatus(UpdateStatusRequest request);
      
    }
}
