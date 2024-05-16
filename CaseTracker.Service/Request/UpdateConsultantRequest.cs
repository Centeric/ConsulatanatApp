using CaseTracker.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.Request
{
    public class UpdateConsultantRequest
    {
        public int Id { get; set; }
        public string? ConsultantId { get; set; }
        public string? TimeShareName { get; set; }
        public string? ClientName { get; set; }
        public int ConsultationStatus { get; set; }
        public string? TimeShareLocation { get; set; }
        public double PaymentReceived { get; set; }
        public string? LeadConsultant { get; set; }
        public string? AssistantConsultant { get; set; }
        public DateTime FilingDate { get; set; }
        public DateTime HearingDate { get; set; }
        public DateTime DeadlineForDocumentSubmission { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public string? CaseSummary { get; set; }
        public Consultant ToEntity(Consultant consultant)
        {



            consultant.TimeShareName = TimeShareName;
            ClientName = ClientName;
            ConsultationStatus = ConsultationStatus;
            TimeShareLocation = TimeShareLocation;
            PaymentReceived = PaymentReceived;
            LeadConsultant = LeadConsultant;
            AssistantConsultant = AssistantConsultant;
            FilingDate = FilingDate;
            HearingDate = HearingDate;
            DeadlineForDocumentSubmission = DeadlineForDocumentSubmission;
            DateOfTransfer = DateOfTransfer;
                CaseSummary = CaseSummary
;
            return consultant;
        }
    }
}
