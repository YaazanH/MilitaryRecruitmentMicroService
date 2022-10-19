using Microsoft.EntityFrameworkCore;

namespace TransportationMinAPI.Data
{
    public class TransportationMinContext : DbContext
    {

        public TransportationMinContext(DbContextOptions<TransportationMinContext> options) : base(options)
        { }

        public DbSet<TransportationMinAPI.Models.Workers> TransportationMinDB { get; set; }

    }
}
