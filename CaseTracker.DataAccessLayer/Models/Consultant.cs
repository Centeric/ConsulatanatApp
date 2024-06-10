using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.Models
{
    public class Consultant
    {
        public int Id { get; set; }
        public string? ConsultationId { get; set; }
        public string? TimeShareName { get; set; }
        public string? ClientName { get; set; }
        public int? ConsultationStatus { get; set; }
        public string? TimeShareLocation { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PaymentReceived { get; set; }
        public string? LeadConsultant { get; set; }
        public string? AssistantConsultant { get; set; }
        public string? FilingDate { get; set; }
        public string? DeadlineForDocumentSubmission { get; set; }
        public string? DateOfTransfer { get; set; }
        public string? CaseSummary { get; set; }
        public string? Email { get; set; }
        public string? ProcessStatus { get; set; }
        public DateTime CreatedDate { get; set; } 
        public virtual ICollection<NextSteps> NextSteps { get; set; } = new List<NextSteps>();
        public virtual ICollection<CommunicationUpdates> CommunicationUpdates { get; set; } = new List<CommunicationUpdates>();
        public virtual ICollection<AttachmentModel> AttachmentModels { get; set; } = new List<AttachmentModel>();
       
    }
    public class ConsultantStatusCount
    {
        public string? ProcessStatus { get; set; }
        public int Count { get; set; }
    }
}
