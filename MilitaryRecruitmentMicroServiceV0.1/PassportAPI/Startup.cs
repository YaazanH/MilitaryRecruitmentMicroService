using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MilitaryCollegeAPI.Data;
using System;
using Consul;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PassportAPI;
using PassportAPI.Data;
using Microsoft.EntityFrameworkCore;

<<<<<<<< HEAD:MilitaryRecruitmentMicroServiceV0.1/MilitaryCollegeAPI/Startup.cs
namespace MilitaryCollegeAPI
========
namespace Passport
>>>>>>>> c4c9bd9f6f6df766c31863df9e2fede3507db9a2:MilitaryRecruitmentMicroServiceV0.1/PassportAPI/Startup.cs
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
<<<<<<<< HEAD:MilitaryRecruitmentMicroServiceV0.1/MilitaryCollegeAPI/Startup.cs

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MilitaryCollegeAPI", Version = "v1" });
            });

========
>>>>>>>> c4c9bd9f6f6df766c31863df9e2fede3507db9a2:MilitaryRecruitmentMicroServiceV0.1/PassportAPI/Startup.cs
            services.AddSingleton<IHostedService, ConsulRegisterService>();
            services.Configure<ServiceConfiguration>(Configuration.GetSection("Service"));
            services.Configure<ConsulConfiguration>(Configuration.GetSection("Consul"));

            var consulAddress = Configuration.GetSection("Consul")["Url"];

            services.AddSingleton<IConsulClient, ConsulClient>(provider =>
                new ConsulClient(config => config.Address = new Uri(consulAddress)));

<<<<<<<< HEAD:MilitaryRecruitmentMicroServiceV0.1/MilitaryCollegeAPI/Startup.cs
            services.AddDbContext<MilitiryCollegeContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MilitaryCollegeContext")));
========
            services.AddDbContext<PassportContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PassportContext")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Passport", Version = "v1" });
            });
>>>>>>>> c4c9bd9f6f6df766c31863df9e2fede3507db9a2:MilitaryRecruitmentMicroServiceV0.1/PassportAPI/Startup.cs
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
<<<<<<<< HEAD:MilitaryRecruitmentMicroServiceV0.1/MilitaryCollegeAPI/Startup.cs
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MilitaryCollegeAPI v1"));
========
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Passport v1"));
>>>>>>>> c4c9bd9f6f6df766c31863df9e2fede3507db9a2:MilitaryRecruitmentMicroServiceV0.1/PassportAPI/Startup.cs
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
