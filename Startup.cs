using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myfirstrazorpages.Services;

namespace myfirstrazorpages
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            // registering the new convention with RazorPagesOptions:
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.Add(new CustomPageRouteModelConvention());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //registers the IPrinter with the dependency injection system, 
            // and specifies that SimulatePrinter is the actual implementation to use.
            services.AddTransient<IPrinter, SimulatePrinter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                // When an error occurs within the specified range, this usage results in a plain text response with a default message
                // app.UseStatusCodePages();

                // or we can format the content
                // app.UseStatusCodePages("text/html", "<h1>Error! Status Code {0}</h1>");

                // make error redirect to some pages by error code
                // app.UseStatusCodePagesWithRedirects("/Error/{0}");

                //or we can use. important! for seo use following:
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
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
