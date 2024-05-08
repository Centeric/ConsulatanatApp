using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.DataAccessLayer.Infrastructure.Services
{
    public class ConsultantService : IConsultantService
    {
        public IUnitOfWork _unitOfWork;
        public ConsultantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(Consultant consultant)
        {
            if (consultant != null)     
            {
                await _unitOfWork.Consultants.Add(consultant);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        //public Task<bool> DeleteProduct()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Consultant>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Consultant> GetConsultantById(string consultationId)
        {

            if (!string.IsNullOrEmpty(consultationId))
            {
                var result = await _unitOfWork.Consultants.
                    GetByConsultationId(consultationId);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public async Task<bool> UpdateConsultation(Consultant consultant)
        {
            if (consultant != null)
            {
                var result = await _unitOfWork.Consultants.GetById(consultant.Id);
                if (result != null)
                {
                    result.ConsultationId = consultant.ConsultationId;
                    result.ConsultationName = consultant.ConsultationName;
                    result.ClientName = consultant.ClientName;
                    result.ConsultationStatus = consultant.ConsultationStatus;
                    result.TimeShare = consultant.TimeShare;
                    result.PaymentReceived = consultant.PaymentReceived;
                    result.LeadConsultant = consultant.LeadConsultant;
                    result.AssistantConsultant = consultant.AssistantConsultant;
                    result.DeadlineForDocumentSubmission = consultant.DeadlineForDocumentSubmission;
                    result.DateOfTransfer = consultant.DateOfTransfer;

                    _unitOfWork.Consultants.Update(result);

                    var response = _unitOfWork.Save();

                    if (response > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
