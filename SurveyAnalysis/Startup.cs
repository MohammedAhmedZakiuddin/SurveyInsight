using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyAnalysis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAnalysis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IEmployee_Survey, InMemoryEmployeeData>();

            services.AddSingleton<IOrganization, InMemoryOrganizationData>();

            services.AddDbContextPool<SurveyAnalysisDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SurveyAnalysisDB"), b => b.MigrationsAssembly("SurveyAnalysis.Data"));

            });

            //services.AddDbContextPool<OrganizationDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("OrganizationDB"), b => b.MigrationsAssembly("SurveyAnalysis.Data"));

            //});

            //services.AddDbContextPool<EmployeeDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("EmployeeDB"), b => b.MigrationsAssembly("SurveyAnalysis.Data"));

            //});

            services.AddScoped<ICountry_Survey, SqlCountryData>();
            services.AddScoped<IOrganization, SqlOrganizationData>();
            services.AddScoped<IEmployee_Survey, SqlEmployeeData>();



            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
