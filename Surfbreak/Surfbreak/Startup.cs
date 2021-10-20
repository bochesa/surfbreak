using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Surfbreak.Models;
using Surfbreak.Models.Surfspot;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Surfbreak
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
            //services.AddDbContext<UserRepository>(options => 
            //{
            //    var connectionString = Configuration.GetConnectionString("UserRepository");
            //    options.UseSqlServer(connectionString);
            //});
            services.AddDbContext<SurfspotDataContext>(options =>
            {
                //Maybe refactor this
                var connectionsString = Configuration.GetConnectionString("DBConnectionString");
                options.UseSqlServer(connectionsString);
            });
            services.AddDbContext<IdentityDataContext>(options => 
            {
                var connectionsString = Configuration.GetConnectionString("DBConnectionString");
                options.UseSqlServer(connectionsString);
            });
            services.AddHttpClient<WeatherConditionProxy>(client =>
                {
                    //client.BaseAddress = new Uri("https://localhost:44302/");
                    client.BaseAddress = new Uri("https://api.surfbreak.dk/");
                }); 
            services.AddTransient<SurfspotRepository>();
            services.AddSingleton<WeatherForecastService>();
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityDataContext>();
            services.AddServerSideBlazor();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapBlazorHub();
            });
            //Custom Middleware implemented as response. Overwritten live by routing. Middleware job check!
            app.UseGetDateMiddleware();
        }
    }
}
