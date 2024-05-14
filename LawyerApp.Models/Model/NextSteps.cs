using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerApp.Models.Model
{
    public class NextSteps
    {
        public int NextStepId { get; set; }
        public string? NextStep { get; set; }
        public int ConsultantId { get; set; } 
        [ForeignKey("ConsultantId")]
        public Consultant? Consultant { get; set; }
    }
}
