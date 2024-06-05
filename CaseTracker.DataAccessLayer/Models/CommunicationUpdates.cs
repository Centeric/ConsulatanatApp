﻿using System;
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
        public string? CommunicatioUpdateTime { get; set; }
     
       
        public int ConsultantId { get; set; }
        [ForeignKey("ConsultantId")]
        public Consultant? Consultant { get; set; }

    }
}
