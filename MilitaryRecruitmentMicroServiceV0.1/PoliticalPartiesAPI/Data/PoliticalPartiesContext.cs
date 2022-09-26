using Microsoft.EntityFrameworkCore;

namespace PoliticalPartiesAPI.Data
{
    public class PoliticalPartiesContext : DbContext
    {
        public PoliticalPartiesContext(DbContextOptions<PoliticalPartiesContext> options) : base(options)
        { }

        public DbSet<PoliticalPartiesAPI.Models.PoliticalParties> PoliticalPartiesDBS { get; set; }
    }
}
