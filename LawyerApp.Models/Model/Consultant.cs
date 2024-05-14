using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.Models.Model
{
    public class Consultant
    {
        public int Id { get; set; }
        public string? ConsultationId { get; set; }
        public string? TimeShareName { get; set; }
        public string? ClientName { get; set; }
        public string? ConsultationStatus { get; set; }
        public string? TimeShare { get; set; }
        public bool PaymentReceived { get; set; }
        public string? LeadConsultant { get; set; }
        public string? AssistantConsultant { get; set; }
        public DateTime FilingDate { get; set; }
        public DateTime HearingDate { get; set; }
        public DateTime DeadlineForDocumentSubmission { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public string? CaseSummary { get; set; }

        public virtual ICollection<NextSteps> NextSteps { get; set; } = new List<NextSteps>();
        public virtual ICollection<CommunicationUpdates> CommunicationUpdates { get; set; } = new List<CommunicationUpdates>();
    }
}
