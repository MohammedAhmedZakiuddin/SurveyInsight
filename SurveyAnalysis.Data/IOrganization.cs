using SurveyAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyAnalysis.Data
{
    public interface IOrganization
    {
        IEnumerable<Organization_Survey> GetOrganizationByName(string name);
        Organization_Survey GetById(int id);
        Organization_Survey Update(Organization_Survey updatedOrganizationSurvey);
        Organization_Survey Add(Organization_Survey newOrganizationSurvey);
        Organization_Survey Delete(int id);
        int Commit();
    }
}

