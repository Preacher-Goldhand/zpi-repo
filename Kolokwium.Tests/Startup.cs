// using Kolokwium.DAL;
// using Kolokwium.Services.Configuration.Profiles;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;

// namespace Kolokwium.Tests {
//     public class Startup {
//         public void ConfigureServices (IServiceCollection services) {
//             services.AddAutoMapper (typeof (MainProfile));
//             services.AddEntityFrameworkInMemoryDatabase ()
//                 .AddDbContext<ApplicationDbContext> (options =>
//                     options.UseInMemoryDatabase ("InMemoryDb")
//                 );

//             // service binding
//             services.AddTransient (typeof (ILogger), typeof (Logger<Startup>));

//             services.SeedData ();
//         }
//     }
// }