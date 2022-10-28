using SurveyAnalysis.Core;
using System.Collections.Generic;
using System.Linq;

namespace SurveyAnalysis.Data
{
    public class InMemoryEmployeeData : IEmployee_Survey
    {
        List<Country_Survey> Countries;
        List<Employee_Survey> Employees;
        List<Organization_Survey> Organizations;
        List<Employee_List> EmployeeLists;

        public Employee_Survey GetById(int id)
        {
            return Employees.SingleOrDefault(r => r.Id == id);
        }

        public Employee_Survey Add(Employee_Survey newEmployee)
        {
            Employees.Add(newEmployee);
            newEmployee.Id = Employees.Max(r => r.Id) + 1;

            return newEmployee;
        }

        public Employee_Survey Update(Employee_Survey updatedEmployeeSurvey)
        {
            var Employee_Survey = Employees.SingleOrDefault(r => r.Id == updatedEmployeeSurvey.Id);

            if (Employee_Survey != null)
            {
                Employee_Survey.EmpNo = updatedEmployeeSurvey.EmpNo;
                Employee_Survey.EmpName_E = updatedEmployeeSurvey.EmpName_E;
                Employee_Survey.EmpName_A = updatedEmployeeSurvey.EmpName_A;
                Employee_Survey.EmpEmail = updatedEmployeeSurvey.EmpEmail;
                Employee_Survey.EmpNetID = updatedEmployeeSurvey.EmpNetID;
                Employee_Survey.ManagerID = updatedEmployeeSurvey.ManagerID;
                Employee_Survey.OrgId = updatedEmployeeSurvey.OrgId;
            }
            return Employee_Survey;
        }

        public int Commit()
        {
            return 0;
        }


        public IEnumerable<Employee_List> GetEmployeeByName(string name = null)
        {
            return from r in EmployeeLists
                   where string.IsNullOrEmpty(name) || r.EmpName_E.ToLower().StartsWith(name) || r.EmpName_E.ToUpper().StartsWith(name)
                   orderby r.Id
                   select r;
        }
        public IEnumerable<Country_Survey> GetAllEmpIds()
        {
            return from r in Countries
                   orderby r.Id
                   select r;
        }
        public IEnumerable<Employee_Survey> GetAllEmployees()
        {
            return from r in Employees
                   orderby r.Id
                   select r;
        }
        public IEnumerable<Organization_Survey> GetAllOrganizations()
        {
            return from r in Organizations
                   orderby r.Id
                   select r;
        }
        public Employee_Survey Delete(int id)
        {
            var Employee_Survey = Employees.FirstOrDefault(r => r.Id == id);
            if (Employee_Survey != null)
            {
                Employees.Remove(Employee_Survey);
            }
            return Employee_Survey;
        }
    }
}
