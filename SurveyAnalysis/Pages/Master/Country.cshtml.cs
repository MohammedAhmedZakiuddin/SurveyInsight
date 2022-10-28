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
    public class CountryModel : PageModel
    {
        private readonly ICountry_Survey country_Data;
        [TempData]
        public string Message_D { get; set; }
        [TempData]
        public string Message_2 { get; set; }
        public IEnumerable<Country_Survey> Countries { get; set; }

        // Bind property usually only supports the post request which is to be used later on to make sure we get it to get request. 
        // Property to work along with the searchterm which is entered by the user. 

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public CountryModel(ICountry_Survey country_Data)
        {
            this.country_Data = country_Data;
        }
        public IEnumerable<Country_Survey> Country { get; set; }


        // OnGet method is used for user input
        public void OnGet()
        {
            Countries = country_Data.GetCountryByName(SearchTerm);
        }
    }
}
