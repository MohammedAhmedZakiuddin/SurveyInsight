using System.Linq;
using SurveyAnalysis.Core;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace SurveyAnalysis.Data
{
    public class SqlCountryData : ICountry_Survey
    {
        private readonly SurveyAnalysisDbContext db;

        public SqlCountryData(SurveyAnalysisDbContext db)
        {
            this.db = db;
        }
        public Country_Survey Add(Country_Survey newEmployee)
        {
            db.Add(newEmployee);
            return newEmployee;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Country_Survey Delete(int id)
        {
            var Country_Survey = GetById(id);
            if(Country_Survey != null)
            {
                db.Countries.Remove(Country_Survey);
            }
            return Country_Survey;
        }

        public Country_Survey GetById(int id)
        {
            return db.Countries.Find(id);
        }

        public IEnumerable<Country_Survey> GetCountryByName(string name)
        {
            var query = from r in db.Countries
                        where r.cName_E.StartsWith(name) || string.IsNullOrEmpty(name) || r.cName_E.ToLower().StartsWith(name) || r.cName_E.StartsWith(name)
                        orderby r.cName_E
                        select r;
            return query;
        }

        public Country_Survey Update(Country_Survey updatedDetails)
        {
            var entity = db.Countries.Attach(updatedDetails);
            entity.State = EntityState.Modified;
            return updatedDetails;
        }
    }
}
