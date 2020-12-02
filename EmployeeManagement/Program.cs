using EmployeeManagement.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            using var db = new EmployeeContext();
            {
                Console.WriteLine("inserting employee data..");
                db.Add(new Employee { Id = 13234, Name = "Milton", Designation = "Accountant", Address = "Dilshad Garden" });
                db.SaveChanges();
                
                //read
                Console.WriteLine("Querrying employee tabel..");
                var employee = db.Employees
                    .OrderBy(b => b.Id)
                    .First();
                Console.WriteLine(employee);
            }

            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
