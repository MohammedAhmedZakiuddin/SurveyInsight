using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SurveyAnalysis.Core;
using SurveyAnalysis.Data;

namespace SurveyAnalysis.Pages.Master
{
    public class OrganizationModel : PageModel
    {
        private readonly IOrganization organizationData;

        public string Message { get; set; }
        [TempData]
        public string Message_2 { get; set; }

        [TempData]
        public string Message_D { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Organization_Survey> Organizations { get; set; }

        public OrganizationModel(IOrganization organizationData)
        {
            this.organizationData = organizationData;
        }
        public void OnGet()
        {
            Message = "DAR-AL-RIYADH IS THE ONLY PARTICIPATING ORGANIZATION.";
            Organizations = organizationData.GetOrganizationByName(SearchTerm);
        }
    }
}
