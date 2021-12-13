using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AlienApi.Models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;


namespace AlienApi
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
      services.AddCors(options =>
      {
        options.AddPolicy("Global",
                          builder =>
                          {
                            builder.AllowAnyOrigin()
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                          });
      });
      services.AddDbContext<AlienApiContext>(opt =>
             opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
      services.AddControllers().AddNewtonsoftJson();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "alien_api",
          Version = "v1",
          Description = "An API for creating a list of aliens",
          TermsOfService = new Uri("https://www.google.com/search?q=generic+terms+of+service+for+api"),
          Contact = new OpenApiContact
          {
            Name = "Benjamin Wilson & Charlie Weber",
            Email = "benjaminw1030@gmail.com, charlestweber@gmail.com",
            Url = new Uri("https://github.com/benjaminw1030"),
          },
          License = new OpenApiLicense
          {
            Name = "Use under MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT"),
          }
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "alien_api v1"));
      }
      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseCors("Global");
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}

