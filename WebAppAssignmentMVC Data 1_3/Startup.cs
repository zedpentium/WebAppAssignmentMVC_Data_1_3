using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models.Interfaces;
using WebAppAssignmentMVC_Data_1_3.Models.Services;
using WebAppAssignmentMVC_Data_1_3.Data;


namespace WebAppAssignmentMVC_Data_1_3
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
            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();  // To use session state /ER

            services.AddSession(options =>  // To use session state /ER
            {
                options.Cookie.Name = ".EricRwebappmvcdata.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(300);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<PeopleDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("PeopleDb")));
            //services.AddDbContext<PeopleDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("IdentityContextConnection")));

            services.AddScoped<IPeopleRepo, DbPeopleRepo>();
            services.AddScoped<ICountryRepo, DbCountryRepo>();
            services.AddScoped<ICityRepo, DbCityRepo>();
            services.AddScoped<ILanguageRepo, DbLanguageRepo>();

            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddRazorPages();

            services.ConfigureApplicationCookie(opts => // Custom Identity Access denied path /ER
            {
                opts.AccessDeniedPath = "/People/AccessDenied";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession(); // To use session state /ER

            app.UseAuthentication();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=People}/{action=Index}/{id?}");
                
                endpoints.MapControllerRoute(
                name: "AjaxSPA",
                pattern: "Ajax/{id?}",
                defaults: new { controller = "Ajax", action = "Index" });

                endpoints.MapControllerRoute(
                name: "Country",
                pattern: "Country/{id?}",
                defaults: new { controller = "Country", action = "Index" });

                endpoints.MapControllerRoute(
                name: "City",
                pattern: "City/{id?}",
                defaults: new { controller = "City", action = "Index" });

                endpoints.MapControllerRoute(
                name: "Language",
                pattern: "Language/{id?}",
                defaults: new { controller = "Language", action = "Index" });

                endpoints.MapControllerRoute(
                name: "PersonDetails",
                pattern: "Details/{id?}",
                defaults: new { controller = "People", action = "PersonDetails" });

                endpoints.MapControllerRoute(
                name: "AddLanguages",
                pattern: "AddLanguagesToPerson/{id?}",
                defaults: new { controller = "People", action = "AddLanguageView" });

                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                name: "Edituserroles",
                pattern: "UserRoles/{id?}",
                defaults: new { controller = "Identity", action = "Index" });

                endpoints.MapControllerRoute(
                name: "CreateRoles",
                pattern: "CreateRole/{id?}",
                defaults: new { controller = "Identity", action = "Create" });

                endpoints.MapControllerRoute(
                name: "UpdateRoles",
                pattern: "UpdateRole/{id?}",
                defaults: new { controller = "Identity", action = "Update" });

                endpoints.MapControllerRoute(
                name: "CheckIfRolesExist",
                pattern: "IsRolesEmpty/{id?}",
                defaults: new { controller = "Identity", action = "IsRolesEmpty" });


            });
        }
    }
}