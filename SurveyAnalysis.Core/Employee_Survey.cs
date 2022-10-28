using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SurveyAnalysis.Core
{
    public class Employee_Survey
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmpNo { get; set; }
        [Required]
        [StringLength(50)]
        public string EmpName_E { get; set; }
        public string EmpName_A { get; set; }
        [Required]
        [StringLength(80)]
        public string EmpEmail { get; set; }

        [ForeignKey("Country_Survey")]
        public int EmpNetID { get; set; }
        public virtual Country_Survey Country_Survey { get; set; }

        [ForeignKey("Employee_Survey")]
        public int ManagerID { get; set; }

        [ForeignKey("Organization_Survey")]
        public int OrgId { get; set; }
        public virtual Organization_Survey Organization_Survey { get; set; }
    }
}
