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
    public class Delete_OrganizationModel : PageModel
    {
        private readonly IOrganization Organziation_Data;

        public Organization_Survey Organization_Survey { get; set; }

        public Delete_OrganizationModel(IOrganization Organziation_data)
        {
            this.Organziation_Data = Organziation_data;
        }
        public IActionResult OnGet(int OrganizationId)
        {
            Organization_Survey = Organziation_Data.GetById(OrganizationId);

            if (Organization_Survey == null)
            {
                return RedirectToPage("./NotFoundO");
            }
            return Page();
        }
        public IActionResult OnPost(int OrganizationId)
        {
            var Organization_Survey = Organziation_Data.Delete(OrganizationId);
            Organziation_Data.Commit();

            if (Organization_Survey == null)
            {
                return RedirectToPage("./NotFoundO");
            }
            TempData["Message_D"] = $"{Organization_Survey.orgName_E} Deleted";
            return RedirectToPage("./Organization");
        }
    }
}
