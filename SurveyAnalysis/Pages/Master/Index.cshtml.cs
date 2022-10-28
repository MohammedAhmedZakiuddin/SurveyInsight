using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SurveyAnalysis.Core;

namespace SurveyAnalysis.Pages.Master
{
    public class IndexModel : PageModel
    {
        public Country_Survey Country_Survey{get; set; }
        public void OnGet(int Country_SurveyId)
        {
            Country_Survey = new Country_Survey();
            Country_Survey.Id = Country_SurveyId;
        }
    }
}
