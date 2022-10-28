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
    public class Edit_CountryModel : PageModel
    {
        private readonly ICountry_Survey countryData;
        public string Message { get; set; }
        public string Message_1 { get; set; }

        // Creating a property that my view can bind to. 
        [BindProperty]
        public Country_Survey Country_Survey { get; set; }
        public Edit_CountryModel(ICountry_Survey countryData)
        {
            this.countryData = countryData;
        }
        public IActionResult OnGet(int? countryId)
        {
            //Country_Survey = countryData.GetById(countryId);

            if (countryId.HasValue)
            {
                Country_Survey = countryData.GetById(countryId.Value);
                Message = "Editing " + Country_Survey.cName_E;
            }

            else
            {
                Country_Survey = new Country_Survey();
                Message_1 = "Adding New Country Details";
            }


            if (Country_Survey == null)
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

            if (Country_Survey.Id > 0)
            {
                countryData.Update(Country_Survey);
            }

            else
            {
                //Country_Survey.Id = Countries.Max(r => r.Id) + 1;
                countryData.Add(Country_Survey);
            }
            TempData["Message_2"] = "Country Details Saved!";

            countryData.Commit();
            return RedirectToPage("./Country", new { Country_SurveyID = Country_Survey.Id });

        }
    }
}
