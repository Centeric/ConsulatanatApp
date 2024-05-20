using CaseTracker.DataAccessLayer.DataServices;
using CaseTracker.DataAccessLayer.IDataServices;
using CaseTracker.DataAccessLayer.Models;
using CaseTracker.DataAccessLayer.Responses;
using CaseTracker.Service.Common;
using CaseTracker.Service.DataLogics.IServices;
using CaseTracker.Service.Request;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CaseTracker.Service.DataLogics.Services
{
    public class ConsultantService : IConsultantService
    {
        private readonly IConsultantRepo _consultantRepo;
       
        private readonly INextStepRepo _nextStepsRepository;
        private readonly ICommunicationUpdateRepo _communicationUpdateRepo;
        private readonly IAttachmentRepo _attachmentRepo;
        private readonly IFileStorageService _fileStorageService;
        private readonly IRepoConsultant _repoConsultant;
        public ConsultantService(IConsultantRepo consultantRepo,  INextStepRepo nextStepsRepository, ICommunicationUpdateRepo communicationUpdateRepo,
            IAttachmentRepo attachmentRepo, IFileStorageService fileStorageService, IRepoConsultant repoConsultant)
        {
            _consultantRepo = consultantRepo; 
           
        _nextStepsRepository = nextStepsRepository;
            _communicationUpdateRepo = communicationUpdateRepo;
            _attachmentRepo = attachmentRepo;
            _fileStorageService = fileStorageService;
            _repoConsultant = repoConsultant;
        }
        public async Task<Result> Add(CreateConsultantRequest consultant)
        {
            int response = await _consultantRepo.Add(consultant.ToEntity());
            
            return response != 0
                ? Result.Success(Constants.Added, consultant)
                : Result.Failure(Constants.NotAdded)!;

        }
        public async Task<Result> UpdateConsultant(UpdateConsultantRequest request)
        {
           
           
            Consultant? consultant = await _repoConsultant.GetAsync(x => x.Id == request.Id);
            if (consultant is null) return Result.Failure(Constants.IdNotFound);
           await _repoConsultant.UpdateAsync(request.ToEntity(consultant));
            return Result.Success(Constants.Updated,request);
        }
        public async Task<Result> Delete(int id)
        {
            Consultant? entity = await _repoConsultant.GetAsync(x=> x.Id == id);
            if (entity is null) return Result.Failure(Constants.IdNotFound);
           // consultant.ConsultationStatus = ;
            await _repoConsultant.DeleteAsync(entity);
            return Result.Success(Constants.Deleted);
        }
        public async Task<Result> DeleteNextStep(int NextStepId)
        {
            NextSteps? entity = await _nextStepsRepository.GetAsync(x=> x.NextStepId == NextStepId);
            if (entity is null) return Result.Failure(Constants.IdNotFound);
            await _nextStepsRepository.DeleteAsync(entity);
            return Result.Success(Constants.Deleted);
        }
        public async Task<Result> DeleteCommunication(int CommunicationId)
        {
            CommunicationUpdates? entity = await _communicationUpdateRepo.GetAsync(x=>x.CommunicationId == CommunicationId);
            if (entity is null) return Result.Failure(Constants.IdNotFound);
            await _communicationUpdateRepo.DeleteAsync(entity);
            return Result.Success(Constants.Deleted);
        }
        public async Task<Result> DeleteAttachment(int AttachmentId)
        {
            AttachmentModel? entity = await _attachmentRepo.GetAsync(x=>x.AttachmentId == AttachmentId);
            if (entity is null) return Result.Failure(Constants.IdNotFound);
            await _attachmentRepo.DeleteAsync(entity);
            return Result.Success(Constants.Deleted);
        }
        public async Task<Result> GetById(string consultationId)
        {
            if (string.IsNullOrEmpty(consultationId))
            {
                return Result.Failure(Constants.EnterData);
            }
            Consultant? consultant = await _consultantRepo.GetById(consultationId);
            if (consultant == null) return Result.Failure(Constants.IdNotFound);

            ConsultantResponse response = new()
            {
               Id = consultant.Id,
               ConsultationId = consultant.ConsultationId,
               TimeShareName = consultant.TimeShareName,
               ClientName = consultant.ClientName,
               ConsultationStatus = consultant.ConsultationStatus,
               TimeShareLocation = consultant.TimeShareLocation,
               PaymentReceived = consultant.PaymentReceived,
               LeadConsultant = consultant.LeadConsultant,
               AssistantConsultant = consultant.AssistantConsultant,
               FilingDate = consultant.FilingDate,
               HearingDate = consultant.HearingDate,
                DeadlineForDocumentSubmission=consultant.DeadlineForDocumentSubmission,
                DateOfTransfer = consultant.DateOfTransfer,
                CaseSummary = consultant.CaseSummary,
                NextSteps = consultant.NextSteps.Select(step => step.NextStep).ToList()!,
                CommunicationUpdates = consultant.CommunicationUpdates.Select(cu => new CommunicationUpdateDTO
                {
                    CommunicationId = cu.CommunicationId,
                    CommunicationUpdate = cu.CommunicationUpdate,
                 
                }).ToList()!,
                AttachmentName = consultant.AttachmentModels.Select(x => x.AttachmentName).ToList()!
                
            };
            return Result.Success(Constants.DataLoaded, response);
        }
        public async Task<Result> GetConsultant()
        {
            var consultant = await _consultantRepo.GetAll();
            if (consultant == null) return Result.Failure(Constants.Error);

            var consultantList = consultant.Select(item => new ConsultantGetResponse
            {
              TimeShareName = item.TimeShareName,
              ConsultationId = item.ConsultationId,
              ClientName = item.ClientName,
              ConsultationStatus = item.ConsultationStatus,
              FilingDate = item.FilingDate,
              DateOfTransfer = item.DateOfTransfer,
            }).ToList();

            return Result.Success(Constants.DataLoaded, consultantList);
        }

        public async Task<Result> CreateNextStep(CreateNextStepRequest request)
        {
            return Result.Success(Constants.Added, await _nextStepsRepository.AddAsync(request.ToEntity()));
        }

        public async Task<Result> CreateCommunicationUpdate(CreateCommunicationRequest request)
        {
            return Result.Success(Constants.Added, await _communicationUpdateRepo.AddAsync(request.ToEntity()));
        }
        public async Task<Result> AddAttachment(CreateAttachmentRequest request)
        {
            try
            {
               
                var filePath = await _fileStorageService.SaveFileAsync(request.File);

             
                var attachment = new AttachmentModel
                {
                    ConsultantId = request.ConsultantId,
                    AttachmentName = filePath,
                    AttachmentType = Path.GetExtension(request.File.FileName)
                };

                await _attachmentRepo.AddAsync(attachment);
                return Result.Success("Added", filePath); 
            }
            catch (Exception ex)
            {
                return Result.Failure("Error", ex.Message);
            }
        }
    }
}
