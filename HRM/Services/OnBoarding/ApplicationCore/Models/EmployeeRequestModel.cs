using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCode.Models
{
    public class EmployeeRequestModel
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Address of the employee")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Please enter Email of the employee")]
        [StringLength(2048)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter EmployeeIdentityId of the employee")]
        public Guid EmployeeIdentityId { get; set; }
        [Required(ErrorMessage = "Please enter EndDate of the employee")]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Please enter FirstName of the employee")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter HireDate of the employee")]
        public DateTime? HireDate { get; set; }
        [Required(ErrorMessage = "Please enter LastName of the employee")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter MiddelName of the employee")]
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter SSN of the employee")]
        [StringLength(2048)]
        public string SSN { get; set; }

    }
}
