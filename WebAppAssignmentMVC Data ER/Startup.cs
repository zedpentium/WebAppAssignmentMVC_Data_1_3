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
using WebAppAssignmentMVC_Data_ER.Models.Interfaces;
using WebAppAssignmentMVC_Data_ER.Models.Services;
using WebAppAssignmentMVC_Data_ER.Data;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebAppAssignmentMVC_Data_ER
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            // Make sure a JS engine is registered, or you will get an error!
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
              .AddV8();

            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();  // To use session state /ER

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



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

            // Initialise ReactJS.NET. Must be before static files.
            app.UseReact(config =>
            {
                // If you want to use server-side rendering of React components,
                // add all the necessary JavaScript files here. This includes
                // your components as well as all of their dependencies.
                // See http://reactjs.net/ for more information. Example:
                /*config
                .AddScript("~/react/index.jsx")
                .AddScript("~/react/Peoplelisttable.jsx")
                .SetJsonSerializerSettings(new JsonSerializerSettings
                 {
                     StringEscapeHandling = StringEscapeHandling.EscapeHtml,
                     ContractResolver = new CamelCasePropertyNamesContractResolver()
                 });*/
                // If you use an external build too (for example, Babel, Webpack,
                // Browserify or Gulp), you can improve performance by disabling
                // ReactJS.NET's version of Babel and loading the pre-transpiled
                // scripts. Example:
                //config
                //  .SetLoadBabel(false)
                //  .AddScriptWithoutTransform("~/js/bundle.server.js");
            });


            app.UseStaticFiles();
            app.UseSession(); // To use session state /ER

            app.UseAuthentication();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();


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

                endpoints.MapControllerRoute(
                name: "ReactIndex",
                pattern: "React/{id?}",
                defaults: new { controller = "React", action = "Index" });

                endpoints.MapControllerRoute(
                name: "Reactapi",
                pattern: "Reactjson/{id?}",
                defaults: new { controller = "React", action = "PersonsList" });

             });
        }
    }
}