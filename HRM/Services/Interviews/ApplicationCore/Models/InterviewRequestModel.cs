using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class InterviewRequestModel
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Begin Time of the interview")]
        public DateTime BeginTime { get; set; }
        [Required(ErrorMessage = "Please enter Candidate Email of the interview")]
        public string CandidateEmail { get; set; }
        [Required(ErrorMessage = "Please enter CandidateFirstName of the interview")]
        [StringLength(50)]
        public string CandidateFirstName { get; set; }
        [Required(ErrorMessage = "Please enter CandidateIdentityId of the interview")]
        public Guid CandidateIdentityId { get; set; }
        [Required(ErrorMessage = "Please enter CandidateLastName of the interview")]
        [StringLength(50)]
        public string CandidateLastName { get; set; }
        [Required(ErrorMessage = "Please enter End Time of the interview")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "Please enter feedback to the interview")]
        public string Feedback { get; set; }
        [Required(ErrorMessage = "Please enter IF Passed the interview")]
        public bool? Passed { get; set; }
        [Required(ErrorMessage = "Please enter Rating of the interview")]
        public int? Rating { get; set; }
        [Required(ErrorMessage = "Please enter SubmissionId of the interview")]
        public int SubmissionId { get; set; }

        //Foreign Key
        //public int InterviewerId { get; set; }
        //public int InterviewTypeId { get; set; }
    }
}
