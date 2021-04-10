using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace zad2REST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\DB.csv";
            WebApplication1.Controllers.StudentsController._studentlist = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => Student.FromCsv(v))
                                           .ToList();
            foreach (Student s in WebApplication1.Controllers.StudentsController._studentlist) {
                Console.WriteLine(s);
            }
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
