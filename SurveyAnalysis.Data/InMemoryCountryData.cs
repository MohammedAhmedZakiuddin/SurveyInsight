using SurveyAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyAnalysis.Data
{
    // Implementing the interface using a class
    // Only works in the development environment.
    public class InMemoryCountryData : ICountry_Survey
    {
        readonly List<Country_Survey> Countries;
        // Some data to test
        public InMemoryCountryData()
        {
            Countries = new List<Country_Survey>()
            {
                new Country_Survey {Id = 1, cCode = "+966", cName_E = "Mohammed Ahmed Zakiuddin", cName_A = "محمد احمد زكي الدين", cNationality_E = "Indian", cNationality_A = "هندي"},
                new Country_Survey {Id = 2, cCode = "+971", cName_E = "Nizamuddin Mohammed", cName_A =  "نظام الدين محمد", cNationality_E = "Emirati", cNationality_A = "إماراتي"},
                new Country_Survey {Id = 3, cCode = "+971", cName_E = "Nizamuddin Mohammed", cName_A =  "نظام الدين محمد", cNationality_E = "Emirati", cNationality_A = "إماراتي"}
            };
        }

        public Country_Survey GetById(int id)
        {
            return Countries.SingleOrDefault(r => r.Id == id);
        }

        public Country_Survey Add(Country_Survey newEmployee)
        {
            newEmployee.Id = Countries.Max(r => r.Id) + 1;
            Countries.Add(newEmployee);
            
            return newEmployee;
        }

        public Country_Survey Update(Country_Survey updatedDetails)
        {
            var country_survey = Countries.SingleOrDefault(r => r.Id == updatedDetails.Id);

            if(country_survey != null)
            {
                country_survey.cCode = updatedDetails.cCode;
                country_survey.cName_E = updatedDetails.cName_E;
                country_survey.cName_A = updatedDetails.cName_A;
                country_survey.cNationality_E = updatedDetails.cNationality_E;
                country_survey.cNationality_A = updatedDetails.cNationality_A;
            }
            return country_survey;
        }

        public int Commit()
        {
            return 0; 
        }

        public IEnumerable<Country_Survey> GetCountryByName(string name = null)
        {
            return from r in Countries
                   where string.IsNullOrEmpty(name) || r.cNationality_E.StartsWith(name) || r.cName_E.ToLower().StartsWith(name) || r.cName_E.StartsWith(name)
                   orderby r.cName_E
                   select r;
        }

        public Country_Survey Delete(int id)
        {
            var country_survey = Countries.FirstOrDefault(r => r.Id == id);
            if(country_survey != null)
            {
                Countries.Remove(country_survey);
            }
            return country_survey;
        }
    }
}
