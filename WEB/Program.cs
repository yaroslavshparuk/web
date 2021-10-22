using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.DAL;

namespace WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                //3. Get the instance of BoardGamesDBContext in our services layer
                var services = scope.ServiceProvider;
                services.GetRequiredService<AppContext>();

                using (var context = new AppContext(scope.ServiceProvider.GetRequiredService<DbContextOptions<AppContext>>()))
                {
                    // Look for any board games.
                    if (context.Users.Any())
                    {
                        return;   // Data was already seeded
                    }

                    context.Users.AddRange(
                        new Models.User
                        {
                           // Id = 1,
                            FullName = "Yaroslav Shparuk",
                            Phone = "132133123123",
                            Age = 20
                        },
                        new Models.User
                        {
                          //  Id = 1,
                            FullName = "Vlad Savustianenko",
                            Phone = "3333333",
                            Age = 19
                        });

                    context.SaveChanges();
                }
            }

            //Continue to run the application
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
