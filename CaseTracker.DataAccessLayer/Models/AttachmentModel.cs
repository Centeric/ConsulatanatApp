﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.Models
{
    public class AttachmentModel
    {
        public int AttachmentId { get; set; }
        public string? AttachmentPath { get; set; }
        public string? AttachmentFileName { get; set; }
        public string? AttachmentType { get; set; }
       
       
        public int ConsultantId { get; set; }
        [ForeignKey("ConsultantId")]
        public Consultant? Consultant { get; set; }
    }
}
