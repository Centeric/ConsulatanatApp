using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.Responses
{
    public class ConsultantResponse
    {
        public int Id { get; set; }
        public string? ConsultationId { get; set; }
        public string? TimeShareName { get; set; }
        public string? ClientName { get; set; }
        public int? ConsultationStatus { get; set; }
        public string? TimeShareLocation { get; set; }
        public bool PaymentReceived { get; set; }
        public string? LeadConsultant { get; set; }
        public string? AssistantConsultant { get; set; }
        public string? FilingDate { get; set; }
     
        public string? DeadlineForDocumentSubmission { get; set; }
        public string? DateOfTransfer { get; set; }
        public string? CaseSummary { get; set; }
        public string? ProcessStatus { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<string> NextSteps { get; set; } = new List<string>();
        public List<NextStepDto> NextStepObject { get; set; } = new List<NextStepDto>();
        public List<CommunicationUpdateDTO> CommunicationUpdates { get; set; } = new List<CommunicationUpdateDTO>();
        public List<AttachmentDTO> Attachments { get; set; } = new List<AttachmentDTO>();
      
    }
    public class CommunicationUpdateDTO
    {
        public int CommunicationId { get; set; }
        public string? CommunicationUpdate { get; set; }
        public string? CommunicationUpdateTime { get; set; }
    }
    public class AttachmentDTO
    {
        public int AttachmentId { get; set; }
        public string? AttachmentPath { get; set; }
        public string? AttachmentFileName { get; set;}
    }
    public class NextStepDto
    {
        public int NextStepId { get; set; }
        public string? NextStep { get; set; }
        public string? NextStepTime { get; set; }
    }
}
