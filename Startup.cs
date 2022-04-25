using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Seniorfolk.Models;
using Seniorfolk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LazZiya.ExpressLocalization;
using System.Globalization;
using Seniorfolk.LocalizationResources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Seniorfolk
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
            var cultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("zh"),
                new CultureInfo("hi"),
                new CultureInfo("ko")
            };

            services.AddRazorPages().AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(
            ops =>
            {
                ops.ResourcesPath = "LocalizationResources";
                ops.RequestLocalizationOptions = o =>
                {
                    o.SupportedCultures = cultures;
                    o.SupportedUICultures = cultures;
                    o.DefaultRequestCulture = new RequestCulture("en");
                };
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //    (options =>
            //{
            //    options.Conventions.AuthorizePage("/AdminHome");
            //});
            services.AddSession();
            services.AddMvc();
            services.AddTransient<VolunteerService>();
            services.AddTransient<UserService>();
            services.AddTransient<TrackerService>();
            services.AddTransient<SurveyService>();
            services.AddTransient<HealthService>();
            services.AddTransient<GroupService>();
            services.AddTransient<FriendService>();
            services.AddTransient<PreferenceService>();
            services.AddTransient<ReportGroupService>();
            services.AddTransient<ReportUserService>();
            services.AddTransient<ApplicationService>();
            services.AddTransient<ContentService>();
            services.AddTransient<HelpService>();
            services.AddDbContext<SeniorFolkDBContext>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            

        }
    }
}
