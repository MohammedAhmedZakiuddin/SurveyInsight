using Microsoft.EntityFrameworkCore;
using SurveyAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyAnalysis.Data
{
    public class SurveyAnalysisDbContext : DbContext
    {
        public SurveyAnalysisDbContext(DbContextOptions<SurveyAnalysisDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Country_Survey> Countries { get; set; }
        public DbSet<Organization_Survey> Organizations { get; set; }
        public DbSet<Employee_Survey> Employees { get; set; }
    }
}
