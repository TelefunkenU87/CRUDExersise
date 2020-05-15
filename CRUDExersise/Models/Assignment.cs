using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int EmployeeId { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        public string Role { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}
