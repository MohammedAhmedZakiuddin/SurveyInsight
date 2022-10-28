using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SurveyAnalysis.Core;
using SurveyAnalysis.Data;

namespace SurveyAnalysis.Pages.Master
{
    public class Edit_EmployeeModel : PageModel
    {
        private readonly IEmployee_Survey employmentData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Employee_Survey Employee_Survey { get; set; }
        public IEnumerable<SelectListItem> EmpIds { get; set; }
        public IEnumerable<SelectListItem> ManagerIDs { get; set; }
        public IEnumerable<SelectListItem> EmpOrdIDs { get; set; }
        public Edit_EmployeeModel(IEmployee_Survey employmentData, IHtmlHelper htmlHelper)
        {
            this.employmentData = employmentData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? employeeId)
        {

            EmpIds = employmentData.GetAllEmpIds().Select(w => new SelectListItem
            {
                Value = w.Id.ToString(),
                Text = w.cCode.ToString()
            });

            ManagerIDs = employmentData.GetAllEmployees().Select(w => new SelectListItem
            {
                Value = w.Id.ToString(),
                Text = w.EmpName_E.ToString()
            });

            EmpOrdIDs = employmentData.GetAllOrganizations().Select(w => new SelectListItem
            {
                Value = w.Id.ToString(),
                Text = w.orgName_E.ToString()
            });

            if (employeeId.HasValue)
            {
                Employee_Survey = employmentData.GetById(employeeId.Value);
            }
            else
            {
                Employee_Survey = new Employee_Survey();
            }
            if (Employee_Survey == null)
            {
                return RedirectToPage("./NotFoundE");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            if (Employee_Survey.Id > 0)
            {
                employmentData.Update(Employee_Survey);
            }
            else
            {
                employmentData.Add(Employee_Survey);
            }

            TempData["Message"] = "Employee Details Saved!";

            employmentData.Commit();
            return RedirectToPage("./Employee", new { employeeId = Employee_Survey.Id });
        }
    }
}
