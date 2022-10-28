using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SurveyAnalysis.Core
{
    public class Country_Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(4)]
        [Required]
        public string cCode { get; set; }
        [Required]
        [StringLength(45)]
        public string cName_E { get; set; }
        [Required]
        [StringLength(45)]
        public string cName_A { get; set; }
        [Required]
        [StringLength(20)]
        public string cNationality_E { get; set; }
        [Required]
        [StringLength(20)]
        public string cNationality_A { get; set; }
    }
}
