using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.Responses
{
    public class NotificationResponse
    {
        public int NotificationId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? NotificationDate { get; set; }
        public bool IsSeen { get; set; }
    }
}
