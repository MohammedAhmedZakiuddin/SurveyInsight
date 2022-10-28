using Microsoft.EntityFrameworkCore;
using SurveyAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyAnalysis.Data
{
    public class SqlEmployeeData : IEmployee_Survey
    {
        private readonly SurveyAnalysisDbContext db;
        public IEnumerable<Employee_List> EmployeeList { get; set; }

        public SqlEmployeeData(SurveyAnalysisDbContext db)
        {
            this.db = db;
        }
        public Employee_Survey Add(Employee_Survey newEmployee)
        {
            db.Add(newEmployee);
            return newEmployee;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Employee_Survey Delete(int Id)
        {
            var Employee_Survey = GetById(Id);
            if (Employee_Survey != null)
            {
                db.Employees.Remove(Employee_Survey);
            }
            return Employee_Survey;
        }

        public Employee_Survey GetById(int id)
        {
            return db.Employees.Find(id);
        }

        public IEnumerable<Employee_List> GetEmployeeByName(string name)
        {

            var query = from E in db.Employees
                        join M in db.Employees on E.ManagerID equals M.Id into EM
                        from EMDetails in EM.DefaultIfEmpty()
                        join O in db.Organizations on E.OrgId equals O.Id into EO
                        from EODetails in EO.DefaultIfEmpty()
                        join N in db.Countries on E.EmpNetID equals N.Id into EN
                        from ENDetails in EN.DefaultIfEmpty()
                        where E.EmpName_E.StartsWith(name) || string.IsNullOrEmpty(name) || E.EmpName_E.ToLower().StartsWith(name) || E.EmpName_E.StartsWith(name)
                        select new Employee_List
                        {
                            Id = E.Id,
                            EmpNo = E.EmpNo,
                            EmpName_E = E.EmpName_E,
                            EmpName_A = E.EmpName_A,
                            EmpEmail = E.EmpEmail,
                            EmpNetID = E.EmpNetID,
                            ManagerID = E.ManagerID,
                            OrgId = E.OrgId,
                            Organization = (EODetails == null ? String.Empty : EODetails.orgName_E),
                            Manager = (EMDetails == null ? String.Empty : EMDetails.EmpName_E),
                            Nationality = (ENDetails == null ? String.Empty : ENDetails.cNationality_E)
                        };

            return query;
        }

        public IEnumerable<Country_Survey> GetAllEmpIds()
        {
            return from r in db.Countries
                   orderby r.Id
                   select r;
        }
        public IEnumerable<Employee_Survey> GetAllEmployees()
        {
            return from r in db.Employees
                   orderby r.Id
                   select r;
        }

        public IEnumerable<Organization_Survey> GetAllOrganizations()
        {
            return from r in db.Organizations
                   orderby r.Id
                   select r;
        }

        public Employee_Survey Update(Employee_Survey updatedEmployeeSurvey)
        {
            var entity = db.Employees.Attach(updatedEmployeeSurvey);
            entity.State = EntityState.Modified;
            return updatedEmployeeSurvey;
        }
    }
}
