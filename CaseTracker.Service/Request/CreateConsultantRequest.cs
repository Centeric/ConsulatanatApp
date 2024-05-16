using CaseTracker.DataAccessLayer.Models;
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
        public string? ConsultationStatus { get; set; }
        public string? TimeShareLocation { get; set; }
        public bool PaymentReceived { get; set; }
        public string? LeadConsultant { get; set; }
        public string? AssistantConsultant { get; set; }
        public DateTime FilingDate { get; set; }
        public DateTime HearingDate { get; set; }
        public DateTime DeadlineForDocumentSubmission { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public string? CaseSummary { get; set; }
      //  public List<CreateNextStepRequest> NextSteps { get; set; } = new List<CreateNextStepRequest>();
       // public List<CreateCommunicationRequest> CommunicationUpdates { get; set; } = new List<CreateCommunicationRequest>();
        public Consultant ToEntity()
        {
            return new Consultant
            {
                
                ConsultationId = ConsultationId,
                TimeShareName = TimeShareName,
                ClientName = ClientName,
                ConsultationStatus = 1,
                TimeShareLocation = TimeShareLocation,
                PaymentReceived = PaymentReceived,
                LeadConsultant = LeadConsultant,
                AssistantConsultant = AssistantConsultant,
                FilingDate = FilingDate,
                HearingDate = HearingDate,
                DeadlineForDocumentSubmission = DeadlineForDocumentSubmission,
                DateOfTransfer = DateOfTransfer,
                CaseSummary = CaseSummary,
               // NextSteps = NextSteps.Select(ns => ns.ToEntity()).ToList(),
               // CommunicationUpdates = CommunicationUpdates.Select(cu => cu.ToEntity()).ToList()
            };
        }
    }
}
