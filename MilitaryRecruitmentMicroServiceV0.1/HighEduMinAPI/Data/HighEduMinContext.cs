using Microsoft.EntityFrameworkCore;
namespace HighEduMinAPI.Data
{
    public class HighEduMinContext : DbContext
    {
        public HighEduMinContext(DbContextOptions<HighEduMinContext> options) : base(options)
        { }

        public DbSet<HighEduMinAPI.Models.HighEduMin> HighEduMinDBS { get; set; }
    }
}
