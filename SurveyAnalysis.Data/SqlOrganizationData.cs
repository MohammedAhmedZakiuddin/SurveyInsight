using SurveyAnalysis.Core;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SurveyAnalysis.Data
{
    public class SqlOrganizationData : IOrganization
    {
        private readonly SurveyAnalysisDbContext db;

        public SqlOrganizationData(SurveyAnalysisDbContext db)
        {
            this.db = db;
        }
        public Organization_Survey Add(Organization_Survey newOrganizationSurvey)
        {
            db.Add(newOrganizationSurvey);
            return newOrganizationSurvey;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Organization_Survey Delete(int id)
        {
            var Organization_Survey = GetById(id);
            if (Organization_Survey != null)
            {
                db.Organizations.Remove(Organization_Survey);
            }
            return Organization_Survey;
        }

        public Organization_Survey GetById(int id)
        {
            return db.Organizations.Find(id);
        }

        public IEnumerable<Organization_Survey> GetOrganizationByName(string name)
        {
            var query = from r in db.Organizations
                        where r.orgName_E.StartsWith(name) || string.IsNullOrEmpty(name) || r.orgName_E.ToLower().StartsWith(name) || r.orgName_E.StartsWith(name)
                        orderby r.Id
                        select r;
            return query;
        }

        public Organization_Survey Update(Organization_Survey updatedOrganizationSurvey)
        {
            var entity = db.Organizations.Attach(updatedOrganizationSurvey);
            entity.State = EntityState.Modified;
            return updatedOrganizationSurvey;
        }
    }

}

