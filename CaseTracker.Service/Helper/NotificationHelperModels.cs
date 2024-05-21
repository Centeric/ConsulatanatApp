using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.Helper.NotificationHelperModels
{
   


        public class NotificationModel
        {
            [JsonProperty("NotificationId")]
            public int NotificationId { get; set; }
            [JsonProperty("IsSeen")]
            public bool IsSeen { get; set; }
            [JsonProperty("Title")]
            public string? Title { get; set; }
            [JsonProperty("Body")]
            public string? Body { get; set; }
        }
    
}
