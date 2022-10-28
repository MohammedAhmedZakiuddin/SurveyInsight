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
    public class EmployeeModel : PageModel
    {
        private readonly IEmployee_Survey employeeData;
        [TempData]
        public string Message { get; set; }
        [TempData]
        public string Message_D { get; set; }

        public IEnumerable<Employee_Survey> Employees { get; set; }
        public IEnumerable<Employee_List> EmployeeList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public EmployeeModel(IEmployee_Survey employeeData)
        {
            this.employeeData = employeeData;
        }
        public void OnGet(string searchTerm)
        {
            EmployeeList = employeeData.GetEmployeeByName(searchTerm);
        }
    }
}
