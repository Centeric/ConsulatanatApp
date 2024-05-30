using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.Models
{
    public class Notifications
    {
        public int NotificationId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public DateOnly NotificationDate { get; set; }
        public bool IsSeen { get; set; }
        
        public string? ConsultationId { get; set; }
    }
}
