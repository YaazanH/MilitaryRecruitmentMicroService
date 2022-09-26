using Microsoft.EntityFrameworkCore;

namespace AirLineAPI.Data
{
    public class AirLineContext : DbContext
    {
        public AirLineContext(DbContextOptions<AirLineContext> options) : base(options)
        { }

        public DbSet<AirLineAPI.Models.AirLine> AirLineDBS { get; set; }
    }
}