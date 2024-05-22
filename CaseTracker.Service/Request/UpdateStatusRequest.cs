using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.Request
{
    public class UpdateStatusRequest
    {
        public string? ConsultationId { get; set; }
        public string? NewStatus { get; set; }
    }
}
