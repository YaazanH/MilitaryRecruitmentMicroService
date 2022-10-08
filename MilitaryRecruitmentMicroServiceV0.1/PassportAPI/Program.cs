using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<<< HEAD:MilitaryRecruitmentMicroServiceV0.1/MilitaryCollegeAPI/Program.cs
namespace MilitaryCollegeAPI
========
namespace Passport
>>>>>>>> c4c9bd9f6f6df766c31863df9e2fede3507db9a2:MilitaryRecruitmentMicroServiceV0.1/PassportAPI/Program.cs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
