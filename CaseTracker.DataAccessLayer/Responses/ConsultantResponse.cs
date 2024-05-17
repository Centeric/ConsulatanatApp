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
        public DateTime FilingDate { get; set; }
        public DateTime HearingDate { get; set; }
        public DateTime DeadlineForDocumentSubmission { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public string? CaseSummary { get; set; }
        public List<string> NextSteps { get; set; } = new List<string>();
        public List<CommunicationUpdateDTO> CommunicationUpdates { get; set; } = new List<CommunicationUpdateDTO>();
        public List<string> AttachmentName { get; set; } = new List<string>();
    }
    public class CommunicationUpdateDTO
    {
        public int CommunicationId { get; set; }
        public string? CommunicationUpdate { get; set; }
        public DateTime CommunicationUpdateTime { get; set; }
    }
}
