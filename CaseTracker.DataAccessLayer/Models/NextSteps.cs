using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.Models
{
        public class NextSteps
        {
            public int NextStepId { get; set; }
            public string? NextStep { get; set; }
            public DateTime NextStepTime { get; set; }
         
     
             public int ConsultantId { get; set; }
             [ForeignKey("ConsultantId")]
            public Consultant? Consultant { get; set; }

        }
}
