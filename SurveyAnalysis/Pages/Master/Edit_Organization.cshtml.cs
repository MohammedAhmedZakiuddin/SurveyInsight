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
    public class Edit_OrganizationModel : PageModel
    {
        private readonly IOrganization organizationData;
        public string Message_4 { get; set; }
        public string Message_3 { get; set; }
        [BindProperty]
        public Organization_Survey Organization_Survey { get; set; }
        public Edit_OrganizationModel(IOrganization organizationData)
        {
            this.organizationData = organizationData;
        }
        public IActionResult OnGet(int? organizationId)
        {

            if (organizationId.HasValue)
            {
                Organization_Survey = organizationData.GetById(organizationId.Value);
                Message_4 = "Editing " + Organization_Survey.orgName_E;
            }
            else
            {
                Message_3 = "Adding New Organization Details!";
                Organization_Survey = new Organization_Survey();
            }
            if (Organization_Survey == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Organization_Survey.Id > 0)
            {
                organizationData.Update(Organization_Survey);
            }
            else
            {
                organizationData.Add(Organization_Survey);
            }
            TempData["Message_2"] = "Organization Details Saved!";


            organizationData.Commit();
            return RedirectToPage("./Organization", new { organizationId = Organization_Survey.Id });

        }
    }
}
