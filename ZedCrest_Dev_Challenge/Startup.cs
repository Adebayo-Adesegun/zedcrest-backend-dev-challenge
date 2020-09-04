using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZedCrest_Dev_Challenge.Services.Implementation;
using ZedCrest_Dev_Challenge.Services.Interface;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace ZedCrest_Dev_Challenge
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
            // Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
            // Note: Add this service at the end after AddMvc() or AddMvcCore().
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ZedCrest Dev Challenge",
                    Version = "v1",
                    Description = @"Develop a RESTful API that accepts a number from 1 to 100. If the Number is not a multiple of 3 or 5 return the number. But for multiples of three return the word 'Fizz' instead of the number and for the multiples of five return 'Buzz'. For numbers which are multiples of both three and five return 'FizzBuzz'.",
                    Contact = new OpenApiContact
                    {
                        Name = "Adebayo Adesegun Daniel",
                        Email = "dadebayo.adesegun@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/adesegun-adebayo-9b122a7b/")
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Set the comments path for the Swagger JSON and UI.
           

            services.AddControllers();

            services.AddScoped<IFizzBuzz, FizzBuzz>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true; // Swashbuckle generates and exposes Swagger JSON in version 3.0 of the specification—officially called the OpenAPI Specification. To support backwards compatibility, you can opt into exposing JSON in the 2.0 format instead
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZedCrest Dev Challenge");

            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
