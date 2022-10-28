using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SurveyAnalysis.Core
{
    public class Organization_Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int orgCode { get; set; }
        [Required]
        [StringLength(45)]
        public string orgName_E { get; set; }
        [Required]
        [StringLength(45)]
        public string orgName_A { get; set; }
        [StringLength(20)]
        public string partner { get; set; }
    }
}
