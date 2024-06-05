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
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CaseTracker.Service.DataLogics.Services
{
    public class ConsultantService : IConsultantService
    {
        private readonly IConsultantRepo _consultantRepo;
        private readonly INotificationService _notificationService;
        private readonly INextStepRepo _nextStepsRepository;
        private readonly ICommunicationUpdateRepo _communicationUpdateRepo;
        private readonly IAttachmentRepo _attachmentRepo;
        private readonly IFileStorageService _fileStorageService;
        private readonly IRepoConsultant _repoConsultant;
        public ConsultantService(IConsultantRepo consultantRepo,  INextStepRepo nextStepsRepository, ICommunicationUpdateRepo communicationUpdateRepo,
            IAttachmentRepo attachmentRepo, IFileStorageService fileStorageService, IRepoConsultant repoConsultant, INotificationService notificationService)
        {
            _consultantRepo = consultantRepo; 
           _notificationService = notificationService;
        _nextStepsRepository = nextStepsRepository;
            _communicationUpdateRepo = communicationUpdateRepo;
            _attachmentRepo = attachmentRepo;
            _fileStorageService = fileStorageService;
            _repoConsultant = repoConsultant;
        }
        public async Task<Result> Add(CreateConsultantRequest consultant)
        {
            var existingConsultant = await _consultantRepo.FindByConsultationId(consultant.ConsultationId!);
            if (existingConsultant != null)
            {
                return Result.Failure("Consultant already exists.");
            }

            if (string.IsNullOrEmpty(consultant.ConsultationId)) return Result.Failure(Constants.NotAllowed);
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
            return Result.Success(Constants.Updated, request);
        }
        public async Task<Result> UpdateStatus(UpdateStatusRequest request)
        {
            var consultant = await _repoConsultant.GetAsync(x=> x.ConsultationId == request.ConsultationId);
            if (consultant == null)
            {
                return Result.Failure(Constants.IdNotFound);
            }
            consultant.ProcessStatus = request.NewStatus;
          
            


                try
                {
                    await _repoConsultant.UpdateAsync(consultant);
                    return Result.Success(Constants.Updated, request);
                }
                catch (Exception ex)
                {
                    return Result.Failure(Constants.Error, ex.Message);
                }
          
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
                DeadlineForDocumentSubmission = consultant.DeadlineForDocumentSubmission,
                DateOfTransfer = consultant.DateOfTransfer,
                CaseSummary = consultant.CaseSummary,
                Email = consultant.Email,
                PhoneNumber = consultant.PhoneNumber,
                ProcessStatus = consultant.ProcessStatus,
                NextSteps = consultant.NextSteps.Select(step => step.NextStep).ToList()!,
                CommunicationUpdates = consultant.CommunicationUpdates.Select(cu => new CommunicationUpdateDTO
                {
                    CommunicationId = cu.CommunicationId,
                    CommunicationUpdate = cu.CommunicationUpdate,

                }).ToList()!,
               Attachments = consultant.AttachmentModels.Select(x => new AttachmentDTO 
                { 
                  AttachmentId = x.AttachmentId,
                  AttachmentPath = x.AttachmentPath, 
                  AttachmentFileName = x.AttachmentFileName,
                }).ToList()!,
                NextStepObject = consultant.NextSteps.Select(st => new NextStepDto
                {
                    NextStepId = st.NextStepId,
                    NextStep = st.NextStep,
                    NextStepTime = st.NextStepTime
                }).ToList(),

            };
            return Result.Success(Constants.DataLoaded, response);
        }
        public async Task<Result> GetConsultant()
        {
            var consultant = await _consultantRepo.GetAll();
            if (consultant == null) return Result.Failure(Constants.Error);

            var consultantList = consultant.Select(item => new ConsultantGetResponse
            {
                Id = item.Id,
              TimeShareName = item.TimeShareName,
              TimeShareLocation = item.TimeShareLocation,
              ConsultationId = item.ConsultationId,
              ClientName = item.ClientName,
              ConsultationStatus = item.ConsultationStatus,
              FilingDate = item.FilingDate,
              ProcessStatus = item.ProcessStatus,
              DateOfTransfer = item.DateOfTransfer,
            }).ToList();

            return Result.Success(Constants.DataLoaded, consultantList);
        }

  
        public async Task<Result> CreateNextStep(CreateNextStepRequest request)
        {
          
            var nextStep = request.ToEntity();
            var addResult = await _nextStepsRepository.AddAsync(nextStep);

            if (addResult == null)
            {
                return Result.Failure(Constants.Error, "Failed to add the NextStep.");
            }

           
           await _notificationService.CreateNotificationAsync(request.ConsultationId, "New NextStep", "A new NextStep has been created.");

         
            return Result.Success(Constants.Added, addResult);
        }

        public async Task<Result> CreateCommunicationUpdate(CreateCommunicationRequest request)
        {
           
            var communication = request.ToEntity();
            var addResult = await _communicationUpdateRepo.AddAsync(communication);

            if (addResult == null)
            {
                return Result.Failure(Constants.Error, "Failed to Add the CommunicationUpdates.");
            }


           await _notificationService.CreateNotificationAsync(request.ConsultationId,"New CommunicationUpdates", "A new CommunicationUpdates has been created.");


            return Result.Success(Constants.Added, addResult);
        }

       
        //public async Task<Result> AddAttachment(List<CreateAttachmentRequest> requests) // Is Ma List of Files
        //{
        //    var addedAttachments = new List<AttachmentModel>();

        //    try
        //    {
        //        string id = requests[0].ConsultationId;
        //        string fileName = requests[0].File.FileName;

        //        foreach (var request in requests)
        //        {
        //            var filePath = await _fileStorageService.SaveFileAsync(request.File);

        //            var attachment = new AttachmentModel
        //            {
        //                ConsultantId = request.ConsultantId,
        //                AttachmentPath = filePath,
        //                AttachmentFileName = Path.GetFileNameWithoutExtension(request.File.FileName),
        //                AttachmentType = Path.GetExtension(request.File.FileName),
        //                // ConsultationId = request.ConsultationId
        //            };

        //            await _attachmentRepo.AddAsync(attachment);
        //            addedAttachments.Add(attachment);


        //        }
        //        await _notificationService.CreateNotificationAsync(id,
        //               "Attachment Added",
        //               $"A new Attachment '{fileName}' has been added."
        //           );

        //        return Result.Success("Added", addedAttachments.Select(a => a.AttachmentPath).ToList());
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Failure("Error", ex.Message);
        //    }
        //}

 
        public async Task<Result> GetConsultantDashboard()
        {
            var consultant = await _consultantRepo.GetAllConsultantForDashboard();
            if (consultant == null) return Result.Failure(Constants.Error);

            var consultantList = consultant.Select(item => new ConsultantGetDashboardResponse
            {
              ConsultationId = item.ConsultationId,
              ClientName = item.ClientName,
              TimeShareName = item.TimeShareName,
              ProcessStatus = item.ProcessStatus,
            }).ToList();

            return Result.Success(Constants.DataLoaded, consultantList);
        }
        public async Task<Result> GetUpcomingConsultant()
        {
            var consultant = await _consultantRepo.GetAllConsultantForUpcoming();
            if (consultant == null) return Result.Failure(Constants.Error);

            var consultantList = consultant.Select(item => new ConsultantGetDashboardResponse
            {
                ConsultationId = item.ConsultationId,
                ClientName = item.ClientName,
                TimeShareName = item.TimeShareName,
                DeadlineForDocumentSubmission = item.DeadlineForDocumentSubmission,
            }).ToList();

            return Result.Success(Constants.DataLoaded, consultantList);
        }
        public async Task<Dictionary<string, object>> GetConsultantByStatus()
        {
            var consultantStatusCounts = await _consultantRepo.GetAllConsultantForStatus();
            if (consultantStatusCounts == null || !consultantStatusCounts.Any())
                return new Dictionary<string, object>
        {
            { "isSuccess", false },
            { "message", Constants.Error }
        };

            var statusCounts = consultantStatusCounts
                .ToDictionary(x => x.ProcessStatus!, x => x.Count);

            var totalCount = consultantStatusCounts.Sum(x => x.Count);

           
            statusCounts["totalCount"] = totalCount;

            return new Dictionary<string, object>
           {
               { "isSuccess", true },
                { "message", Constants.DataLoaded },
               { "data", statusCounts }
            };
        }
        public async Task<Result> AddAttachment(CreateAttachmentDTO dto)
        {
            var addedAttachments = new List<AttachmentModel>();
            var attachmentFilenames = new List<string>();

            try
            {
                foreach (var file in dto.Files)
                {
                    var filePath = await _fileStorageService.SaveFileAsync(file);

                    var attachment = new AttachmentModel
                    {
                        ConsultantId = dto.ConsultantId,
                        AttachmentPath = filePath,
                        AttachmentFileName = Path.GetFileNameWithoutExtension(file.FileName),
                        AttachmentType = Path.GetExtension(file.FileName),
                       
                    };

                    await _attachmentRepo.AddAsync(attachment);
                    addedAttachments.Add(attachment);

                    attachmentFilenames.Add(file.FileName);
                }

              
                if (!string.IsNullOrEmpty(dto.ConsultationId))
                {
                    var filenames = string.Join(", ", attachmentFilenames);

                    await _notificationService.CreateNotificationAsync(
                        dto.ConsultationId,
                        "Attachments Added",
                        $"New attachments have been added: {filenames}"
                    );
                }

                return Result.Success("Added", addedAttachments.Select(a => a.AttachmentPath).ToList());
            }
            catch (Exception ex)
            {
                return Result.Failure("Error", ex.Message);
            }
        }


    }
}
