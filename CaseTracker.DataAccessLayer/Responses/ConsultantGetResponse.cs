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
        public string? ClientName { get; set; }
        public int? ConsultationStatus { get; set; }
      
        public DateTime FilingDate { get; set; }
      
      
        public DateTime DateOfTransfer { get; set; }
      
    }
}
