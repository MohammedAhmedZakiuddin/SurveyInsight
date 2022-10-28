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
    public class Delete_CountryModel : PageModel
    {
        private readonly ICountry_Survey country_Data;

        public Country_Survey Country_Survey { get; set; }

        public Delete_CountryModel(ICountry_Survey country_Data)
        {
            this.country_Data = country_Data;
        }
        public IActionResult OnGet(int countryId)
        {
            Country_Survey = country_Data.GetById(countryId);

            if (Country_Survey == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int countryId)
        {
            var country_Survey = country_Data.Delete(countryId);
            country_Data.Commit();

            if (country_Survey == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message_D"] = $"{country_Survey.cName_E} Deleted";
            return RedirectToPage("./Country");
        }
    }
}
