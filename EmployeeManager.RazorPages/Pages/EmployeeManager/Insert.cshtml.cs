using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.RazorPages.Pages.EmployeeManager
{
    public class InsertModel : PageModel
    {
        private readonly AppDbContext db = null;
        public string Message { get; set; }
        [BindProperty]
        public Employee Employee { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public InsertModel(AppDbContext _db)
        {
            this.db = _db;
        }
        public void FillCountries()
        {
            List<SelectListItem> countries =
                 (from c in db.Countries
                  orderby c.Name ascending
                  select new SelectListItem()
                  {
                      Text = c.Name,
                      Value = c.Name
                  }).ToList();
            this.Countries = countries;
        }
        public void OnGet()
        {
            FillCountries();
        }
        public void OnPost()
        {
            FillCountries();
            if (ModelState.IsValid)
            {
                try
                {
                    db.Employees.Add(Employee);
                    db.SaveChanges();
                    Message = "Employee inserted successfully!";
                }
                catch (DbUpdateException ex1)
                {
                    Message = ex1.Message + "\n\n" + ex1.StackTrace;
                }
            }
        }
    }
}
