using Microsoft.EntityFrameworkCore;


namespace HealthMinAPI.Data
{
    public class HealthMinContext : DbContext
    {
        public HealthMinContext(DbContextOptions<HealthMinContext> options) : base(options)
        { }

        public DbSet<HealthMinAPI.Models.HealthMin> HealthMinDBS { get; set; }
    }
}
