﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class InterviewResponseModel
    {
        public int Id { get; set; }

        public DateTime BeginTime { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidateFirstName { get; set; }
        public Guid CandidateIdentityId { get; set; }
        public string CandidateLastName { get; set; }
        public DateTime EndTime { get; set; }

        public string Feedback { get; set; }

        public bool? Passed { get; set; }
        public int? Rating { get; set; }

        public int SubmissionId { get; set; }

        //Foreign Key
        public int InterviewerId { get; set; }

        public int InterviewTypeId { get; set; }
    }
}
