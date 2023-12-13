using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Kolokwium.Tests
{
    public static class Extensions
    {
        // Create sample data
        public static async void SeedData(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            // other seed data ...
         
            // save changes
            await dbContext.SaveChangesAsync();
        }
    }
}
