using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace QuickWeb.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        
        public void ConfigureServices(IServiceCollection services)
        {
            
            var mvcBuilder = services.AddRazorPages();

            
            mvcBuilder.AddRazorRuntimeCompilation(option =>
            {
            });

            
            services.AddServerSideBlazor();

            
            services.Configure<CookiePolicyOptions>(options =>
            {
                
                options.CheckConsentNeeded = context => true;
                
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            
            services.AddAuthentication("Quick.Web.Cookie")
                    .AddCookie("Quick.Web.Cookie");

            
            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();
            
            services.AddHttpClient();
            services.AddScoped<HttpClient>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            
            app.UseStaticFiles();

            
            app.UseCookiePolicy();

            
            app.UseAuthentication();

            
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings.Add(".less", "stylesheet/less");
            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = provider
            });

            
            app.UseHttpsRedirection();

            
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("{action=}", "/_Host");
                endpoints.MapFallbackToPage("{controller=View}/{action=}", "/_Page");
            });
        }
    }
}