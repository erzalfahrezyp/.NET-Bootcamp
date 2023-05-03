using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateAsyncScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        // private static void SeedData(AppDbContext context, bool isProduction)
        // {
        //     if (isProduction)
        //     {
        //         Console.WriteLine("--> Migrating data using EF Core");
        //         try
        //         {
        //             context.Database.Migrate();
        //         }
        //         catch (Exception ex)
        //         {
        //             Console.WriteLine($"--> Could not migrate the database {ex.Message}");
        //         }
        //     }
        // }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Platforms.AddRange(
                new Platform()
                {
                    Name = "Dotnet Core", 
                    Publisher = "Microsoft", 
                    Cost = "Free"
                },
                new Platform()
                {
                    Name = "SQL Server Express", 
                    Publisher = "Microsoft", 
                    Cost = "Free"
                },
                new Platform()
                {
                    Name = "Kubernetes", 
                    Publisher = "Cloud Native Computing Foundation", 
                    Cost = "Free"
                }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}