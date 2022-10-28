using SurveyAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyAnalysis.Data
{
    public interface IEmployee_Survey
    {
        IEnumerable<Employee_List> GetEmployeeByName(string name);
        IEnumerable<Country_Survey> GetAllEmpIds();
        IEnumerable<Employee_Survey> GetAllEmployees();
        IEnumerable<Organization_Survey> GetAllOrganizations();
        Employee_Survey GetById(int id);
        Employee_Survey Add(Employee_Survey newEmployee);
        Employee_Survey Update(Employee_Survey updatedEmployeeSurvey);
        Employee_Survey Delete(int Id);
        int Commit();

    }
}
