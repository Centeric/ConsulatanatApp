using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.Models
{
    public class CommunicationUpdates
    {
        public int CommunicationId { get; set; }
        public string? CommunicationUpdate { get; set; }
        public DateTime CommunicatioUpdateTime { get; set; }
        public int ConsultantId { get; set; }
        [ForeignKey("ConsultationId")]
        public Consultant? Consultant { get; set; }

    }
}
