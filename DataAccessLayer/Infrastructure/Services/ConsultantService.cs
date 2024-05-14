using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using LawyerApp.Models.ViewModel;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        public async Task<bool> CreateNextSteps(NextStepView next)
        {
            if (next != null)
            {

                var nextStepsEntity = new NextSteps
                {
                    NextStep = next.NextStep,
                    ConsultantId = next.ConsultantId
                };

                await _unitOfWork.NextSteps.Add(nextStepsEntity);
                var result = _unitOfWork.Save();

                return result > 0;
            }
            return false;

        }
        public async Task<bool> CreateCommunicationUpdate(CommunicationUpdateView inp)
        {
            if (inp != null)
            {

                var communicationEntity = new CommunicationUpdates
                {
                    CommunicationUpdate = inp.CommunicationUpdate,
                    ConsultantId = inp.ConsultantId
                };

                await _unitOfWork.CommunicationUpdates.Add(communicationEntity);
                var result = _unitOfWork.Save();

                return result > 0;
            }
            return false;

        }

        public async Task<bool> DeleteById(int id)
        {
            if (id > 0)
            {
                var result = await _unitOfWork.Consultants.GetById(id);
                if (result != null)
                {
                    _unitOfWork.Consultants.Delete(result);
                    var response = _unitOfWork.Save();

                    if (response > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ConsultantView>> GetAllConsultant()
        {
            var consultantList = await _unitOfWork.Consultants.GetAll();
          

            return null;
           
        }

        public async Task<ConsultantView> GetConsultantById(string consultationId)
        {

            if (!string.IsNullOrEmpty(consultationId))
            {
                var result = await _unitOfWork.Consultants.
                    GetByConsultationId(consultationId);
                if (result == null)
                {
                    return null;
                }
                var viewModel = new ConsultantView
                {
                    Id = result.Id,
                    ConsultationId = result.ConsultationId,
                    TimeShareName= result.TimeShareName,
                    ClientName = result.ClientName,
                    ConsultationStatus = result.ConsultationStatus,
                    TimeShare = result.TimeShare,
                    PaymentReceived = result.PaymentReceived,
                    LeadConsultant = result.LeadConsultant,
                    AssistantConsultant = result.AssistantConsultant,
                    FilingDate = result.FilingDate,
                    HearingDate = result.HearingDate,
                    DeadlineForDocumentSubmission = result.DeadlineForDocumentSubmission,
                    DateOfTransfer = result.DateOfTransfer,
                    CaseSummary= result.CaseSummary,
                    NextSteps = result.NextSteps.Select(n => n.NextStep).ToList(),
                    CommunicationUpdates = result.CommunicationUpdates.Select(c => c.CommunicationUpdate).ToList()
                };
                return viewModel;
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
                   // result.ConsultationId = consultant.ConsultationId;
                    result.TimeShareName = consultant.TimeShareName;
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
