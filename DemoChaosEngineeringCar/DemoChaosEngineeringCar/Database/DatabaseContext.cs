using DemoChaosEngineeringCar.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoChaosEngineeringCar.Database
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Car> Cars { get; set; }
    }
}
