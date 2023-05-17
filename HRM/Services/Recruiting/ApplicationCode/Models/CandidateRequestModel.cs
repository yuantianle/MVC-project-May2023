using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCode.Models
{
    public class CandidateRequestModel
    {
        //remember define id and createon date auto matically 
        [Required(ErrorMessage = "Please enter the Email of the candidate")]
        [StringLength(512)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter the First Name of the candidate")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the Last Name of the candidate")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter the Middle Name of the candidate")]
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter the Resume URL of the candidate")]
        [StringLength(2048)]
        public string ResumeURL { get; set; }
    }
}
