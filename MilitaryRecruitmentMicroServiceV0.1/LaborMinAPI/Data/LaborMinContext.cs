using Microsoft.EntityFrameworkCore;

namespace LaborMinAPI.Data
{
    public class LaborMinContext : DbContext
    {
        public LaborMinContext(DbContextOptions<LaborMinContext> options) : base(options)
        { }

        public DbSet<LaborMinAPI.Models.Workers> LaborMinDB { get; set; }
    }
}
