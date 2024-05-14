using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.Models.ViewModel
{
    public class ConsultantView
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
        public List<string>? NextSteps { get; set; }
        public List<string>? CommunicationUpdates { get; set; }
    }
}
