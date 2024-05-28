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
                NextStepTime = NextStepTime
            };
        }
    }
    public record CreateCommunicationRequest(
        int ConsultantId,
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
                CommunicatioUpdateTime = CommunicationUpdateTime
            };
        }
    }
    public record CreateAttachmentRequest(
     // string FileName,
      int ConsultantId,
      IFormFile File
  )
    {
        public AttachmentModel ToEntity(string filePath)
        {
            return new AttachmentModel
            {
                ConsultantId = ConsultantId,
                AttachmentName = filePath,
                AttachmentType = Path.GetExtension(File.FileName),
                
                
            };
        }
    }
}

    

