using SurveyAnalysis.Core;
using System.Collections.Generic;
using System.Linq;

namespace SurveyAnalysis.Data
{
    public class InMemoryOrganizationData : IOrganization
    {
        readonly List<Organization_Survey> Organizations;
        public InMemoryOrganizationData()
        {
            Organizations = new List<Organization_Survey>()
            {
                new Organization_Survey {Id = 1, orgCode = 1001, orgName_E = "DAR AL RIYADH", orgName_A = "دار الرياض", partner = "HEAD OFFICE"},
                new Organization_Survey {Id = 2, orgCode = 1002, orgName_E = "PARSONS", orgName_A = "بارسونز", partner = "PARTNER"},
                new Organization_Survey {Id = 3, orgCode = 1003, orgName_E = "WIPRO", orgName_A = "ويبرو", partner = "PARTNER"},
                new Organization_Survey {Id = 4, orgCode = 1004, orgName_E = "MASSADR", orgName_A = "مصدر", partner = "PARTNER" },
                new Organization_Survey {Id = 5, orgCode = 1005, orgName_E = "CBRE", orgName_A = "جبصه", partner = "PARTNER" },
                new Organization_Survey {Id = 6, orgCode = 1006, orgName_E = "TECHNICFMC", orgName_A = "تقنية", partner = "PARTNER" }
            };

        }
        public Organization_Survey GetById(int id)
        {
            return Organizations.SingleOrDefault(r => r.Id == id);
        }

        public Organization_Survey Add(Organization_Survey newEmployee)
        {
            Organizations.Add(newEmployee);
            newEmployee.Id = Organizations.Max(r => r.Id) + 1;

            return newEmployee;
        }

        public Organization_Survey Update(Organization_Survey updatedOrganizationSurvey)
        {
            var Organization_Survey = Organizations.SingleOrDefault(r => r.Id == updatedOrganizationSurvey.Id);

            if (Organization_Survey != null)
            {
                Organization_Survey.orgCode = updatedOrganizationSurvey.orgCode;
                Organization_Survey.orgName_E = updatedOrganizationSurvey.orgName_E;
                Organization_Survey.orgName_A = updatedOrganizationSurvey.orgName_A;
                Organization_Survey.partner = updatedOrganizationSurvey.partner;
            }
            return Organization_Survey;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Organization_Survey> GetOrganizationByName(string name = null)
        {
            return from r in Organizations
                   where string.IsNullOrEmpty(name) || r.orgName_E.ToLower().StartsWith(name) || r.orgName_E.ToUpper().StartsWith(name)
                   orderby r.Id
                   select r;
        }

        public Organization_Survey Delete(int id)
        {
            var Organization_Survey = Organizations.FirstOrDefault(r => r.Id == id);
            if (Organization_Survey != null)
            {
                Organizations.Remove(Organization_Survey);
            }
            return Organization_Survey;
        }
    }
}
