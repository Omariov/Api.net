using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI
{
    public class MydbContexte : DbContext
    {
        public DbSet<Etudiant> Etudiants { get; set; }
        public MydbContexte(DbContextOptions options) : base(options)
        {

        }
        public static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MydbContexte>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }


        }
    }
}
