using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Surfbreak.Api.Models;
using System;
using System.IO;
using System.Reflection;

namespace Surfbreak.Api
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
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddHttpClient<WeatherConditionProxy>(client =>
            {
                client.BaseAddress = new Uri("https://forecast.metoceanapi.com/v0/ocean/ec/");
            });
            services.AddControllers().AddXmlSerializerFormatters();

            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //    {
            //        builder.WithOrigins("https://localhost:44320")
            //        .AllowAnyHeader()
            //        .AllowAnyMethod();
            //    });
            //});

                                                services.AddAuthentication("Bearer")
                                                    .AddJwtBearer("Bearer", options =>
                                                    {
                                                        //Identity server URL
                                                        options.Authority = "https://identity.surfbreak.dk";
                                                        options.RequireHttpsMetadata = false;

                                                        //options.Audience = "SurfbreakApi";
                                                        options.TokenValidationParameters = new TokenValidationParameters { ValidateAudience = false };
                                                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Surfbreak");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}