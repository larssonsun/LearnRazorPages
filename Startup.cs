using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
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

            // fource to use https （注意要关系浏览器的HSTS，否则无法测试成功）
            // make sure the statment "app.UseHttpsRedirection();" is disabled
            services.Configure<MvcOptions>(options =>
            {
                // // if we use "Permanent" prop , broswer will receive 301 instead of 302
                // // 这里测试环境下有个问题，我不知道如何制定ssl的远程端口，当前ide host的环境默认是https:5001。于是301->403
                // options.Filters.Add(new RequireHttpsAttribute { Permanent = true });
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
                
                // // 使用urlrewriting重定向到https （注意要关系浏览器的HSTS，否则无法测试成功）
                // // make sure the statment "app.UseHttpsRedirection();" is disabled
                // // 1、使用 AddRedirectToHttpsPermanent 永久定向到https，但是测试服务器的https远程端口是5001而不是80
                // var options = new RewriteOptions().AddRedirectToHttpsPermanent();

                // // 2、使用AddRedirectToHttps，同时指定ssl的端口为5001，因为测试服务器的host默认是5001
                // // (测试环境下使用其他端口将无法重定向成功：“localhost 拒绝了我们的连接请求”)
                // var options = new RewriteOptions().AddRedirectToHttps(301, 5002);

                // app.UseRewriter(options);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            // // 注释下列语句时注意要关系浏览器的HSTS，否则无法测试成功
            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
