using SurveyAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyAnalysis.Data
{
    public interface ICountry_Survey
    {
        // IEnumerable is to display all the names of the list but also helps to search for a particular name. 
        IEnumerable<Country_Survey> GetCountryByName(string name);
        Country_Survey GetById(int id);

        // Creating a new method to return the employee details.
        Country_Survey Update(Country_Survey updatedDetails);
        Country_Survey Add(Country_Survey newEmployee);
        Country_Survey Delete(int id);
        int Commit();
    }
}
