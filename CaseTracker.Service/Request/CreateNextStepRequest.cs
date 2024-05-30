using CaseTracker.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.Request
{
    public record CreateNextStepRequest(
        string? ConsultationId,
        int ConsultantId, 
        string? NextStep,
        DateTime NextStepTime)
    {
        public NextSteps ToEntity()
        {
            return new NextSteps
            {
                ConsultantId = ConsultantId,  
                NextStep = NextStep,
                NextStepTime = NextStepTime,
               // ConsultationId = ConsultationId,
            };
        }
    }
    public record CreateCommunicationRequest(
        int ConsultantId,
        string? ConsultationId,
        string? CommunicationUpdate,
        DateTime CommunicationUpdateTime
        )
    {
        public CommunicationUpdates ToEntity()
        {
            return new CommunicationUpdates
            {
                ConsultantId = ConsultantId,
                CommunicationUpdate = CommunicationUpdate,
                CommunicatioUpdateTime = CommunicationUpdateTime,
               // ConsultationId = ConsultationId,
            };
        }
    }
    public record CreateAttachmentRequest(
      int ConsultantId,
      string? ConsultationId,
      IFormFile File
     )
    {
        public AttachmentModel ToEntity(string filePath)
        {
            return new AttachmentModel
            {
                ConsultantId = ConsultantId,
                AttachmentPath = filePath,
                AttachmentFileName = Path.GetFileNameWithoutExtension(File.FileName),
                AttachmentType = Path.GetExtension(File.FileName),
               // ConsultationId = ConsultationId,
                
            };
        }
    }
}

    

