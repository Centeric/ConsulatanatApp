using CaseTracker.DataAccessLayer.Models;
using CaseTracker.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.Request
{
    public sealed class CreateConsultantRequest
    {
          
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
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
      //  public string? ProcessStatus { get; set; }

        public Consultant ToEntity()
        {
            return new Consultant
            {
                
                ConsultationId = ConsultationId,
                TimeShareName = TimeShareName,
                ClientName = ClientName,
                ConsultationStatus = ConsultationStatus ?? 0,
                TimeShareLocation = TimeShareLocation,
                PaymentReceived = PaymentReceived,
                LeadConsultant = LeadConsultant,
                AssistantConsultant = AssistantConsultant,
                FilingDate = FilingDate,
                ProcessStatus = Constants._ConsultantStatus.StatusPending,
                DeadlineForDocumentSubmission = DeadlineForDocumentSubmission,
                DateOfTransfer = DateOfTransfer,
                CaseSummary = CaseSummary,
                Email = Email,
                PhoneNumber = PhoneNumber
             
            };
        }
    }
}
