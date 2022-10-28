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
    public class Delete_EmployeeModel : PageModel
    {
        private readonly IEmployee_Survey employee_Data;

        public Employee_Survey Employee_Survey { get; set; }

        public Delete_EmployeeModel(IEmployee_Survey Employee_Data)
        {
            this.employee_Data = Employee_Data;
        }
        public IActionResult OnGet(int EmployeeId)
        {
            Employee_Survey = employee_Data.GetById(EmployeeId);

            if (Employee_Survey == null)
            {
                return RedirectToPage("./NotFoundE");
            }
            return Page();
        }

        public IActionResult OnPost(int EmployeeId)
        {
            var Employee_Survey = employee_Data.Delete(EmployeeId);
            employee_Data.Commit();

            if (Employee_Survey == null)
            {
                return RedirectToPage("./NotFoundE");
            }
            TempData["Message_D"] = $"{Employee_Survey.EmpName_E} Deleted";
            return RedirectToPage("./Employee");
        }
    }
}
