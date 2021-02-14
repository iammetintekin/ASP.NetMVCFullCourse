using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcFullCourse.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Your Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Select Your Department")]
        public Nullable<int> departmentId { get; set; }
        [Required(ErrorMessage = "Enter Your Country")]
        public string adress { get; set; }

        public string departmentname { get; set; }
        public string SiteName { get; set; }
    }
}