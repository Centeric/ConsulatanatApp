using CaseTracker.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.Responses
{
    public class ConsultantGetResponse
    {
        public int Id { get; set; }
        public string? ConsultationId { get; set; }
        public string? TimeShareName { get; set; }
        public string? TimeShareLocation { get; set; }
        public string? ClientName { get; set; }
        public int? ConsultationStatus { get; set; }
      
        public string? FilingDate { get; set; }

        public string? ProcessStatus { get; set; }
        public string? DateOfTransfer { get; set; }
      
    }
    public class ConsultantGetDashboardResponse
    {
     
        public string? ConsultationId { get; set; }
        public string? TimeShareName { get; set; }
    
        public string? ClientName { get; set; }
        
        public string? ProcessStatus { get; set; }
        public string? DeadlineForDocumentSubmission { get; set;}
    }
    public class ConsultantGetStatusResponse
    {


        public Dictionary<string, int> StatusCounts { get; set; }
        public int TotalCount { get; set; }

    }
}
