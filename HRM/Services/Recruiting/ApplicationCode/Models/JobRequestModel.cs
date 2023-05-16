using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCode.Models
{
    public class JobRequestModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter Title of the job")]
        [StringLength(256)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Description of the job")]
        [StringLength(5000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Start Date of the job")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter Number of Positions of the job")]
        [Range(1, 1000)]
        public int NumberOfPositions { get; set; }
    }
}
