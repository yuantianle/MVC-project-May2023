using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        [MaxLength(2048)]
        public string Email { get; set; }
        public Guid EmployeeIdentityId { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [MaxLength(2048)]
        public string SSN { get; set; }

        //Foreign Key
        public int EmployeeStatusId { get; set; }


    }
}
